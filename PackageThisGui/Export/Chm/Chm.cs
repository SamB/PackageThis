// Copyright (c) Microsoft Corporation.  All rights reserved.
//
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace PackageThis
{
    class Chm : ICompilable
    {
        private string withinChmDir;
        private string rawDir;
        private string chmDir;
        private string chmSubDir = "html";

        private string baseName;

        private string workingDir;
        private string title;
        private string chmFile;
        private string locale;
        private Content contentDataSet;
        private TreeNodeCollection nodes;
        private Dictionary<string, string> links;

        private string defaultPage = null;

        private IProgressReporter progressReporter = null;

        public int expectedLines;

        // {0} = filename with full path (c:\file.chm)
        // {1} = filename without extension
        // {2} = LCID
        // {3} = default page
        // {4} = title
        static readonly String crlf = Environment.NewLine;
        static string template = "[OPTIONS]" + crlf +
            "Auto Index=Yes" + crlf +
            "Compatibility=1.1 or later" + crlf +
            "Compiled file={0}" + crlf +
            "Contents file={1}.hhc" + crlf +
            "Create CHI file=No" + crlf +
            "Default Window=msdn" + crlf +
            "Default topic={3}" + crlf +
            "Display compile progress=Yes" + crlf +
            "Enhanced decompilation=Yes" + crlf +
            "Error log file={1}.log" + crlf +
            "Full-text search=Yes" + crlf +
            "Index file={1}.hhk" + crlf +
            "Language=0x{2:x}" + crlf + // in hex, eg. 0x0409
            "Title={4}" + crlf +
            "Binary TOC=Yes" + crlf +   // this enables MSDN style Next\Prev button (although stops merging if anyone wants to do that later)
            "Binary Index=Yes" + crlf + crlf +

            "[WINDOWS]" + crlf +
            "msdn=\"{4}\",\"{1}.hhc\",\"{1}.hhk\",\"{3}\",\"{3}\",,\"MSDN Library\",,\"MSDN Online\",0x73520,240,0x60387e,[30,30,770,540],0x30000,,,,,,0" + crlf + crlf +

            "[FILES]" + crlf +
            "green-left.jpg" + crlf +
            "green-middle.jpg" + crlf +
            "green-right.jpg" + crlf + crlf +


            "[INFOTYPES]" + crlf;


        static private Stream resourceStream = typeof(AppController).Assembly.GetManifestResourceStream("PackageThis.Extra.chm.xslt");
        static private XmlReader transformFile = XmlReader.Create(resourceStream);
        static private XslCompiledTransform xform = null;


        public Chm(string workingDir, string title, string chmFile, string locale, 
            TreeNodeCollection nodes,
            Content contentDataSet, 
            Dictionary<string, string> links)
        {
            this.workingDir = workingDir;
            this.title = title;
            this.chmFile = chmFile;
            this.locale = locale;
            this.nodes = nodes;
            this.contentDataSet = contentDataSet;
            this.links = links;

            this.rawDir = Path.Combine(workingDir, "raw");

            // The source shouldn't be hidden away. If an error happens (likely) the user needs to check logs etc.
            //this.chmDir = Path.Combine(workingDir, "chm");   
            this.chmDir = GetUniqueDir(chmFile);
            this.withinChmDir = Path.Combine(chmDir, chmSubDir);
            this.baseName = Path.GetFileNameWithoutExtension(chmFile);

            if (xform == null)
            {
                xform = new XslCompiledTransform(true);
                xform.Load(transformFile);
            }

        }

        private string GetUniqueDir(string targetFile)
        {
            string basedir = Path.ChangeExtension(targetFile, "ProjectSource");
            string dir = basedir;
            int x = 0;
            while (Directory.Exists(dir))
            {
                x++;
                string num = x.ToString();
                dir = basedir + "." + num.PadLeft(3, '0');
            }
            return dir;   //return a folder that does not exist
        }


        public void Create()
        {
            if (Directory.Exists(chmDir) == true)
            {
                Directory.Delete(chmDir, true);
            }

            Directory.CreateDirectory(chmDir);
            Directory.CreateDirectory(withinChmDir);

            foreach (string file in Directory.GetFiles(rawDir))
            {
                File.Copy(file, Path.Combine(withinChmDir, Path.GetFileName(file)), true);
            }

            Hhk hhk = new Hhk(Path.Combine(chmDir, baseName + ".hhk"), locale);

            foreach (DataRow row in contentDataSet.Tables["Item"].Rows)
            {
                //RWC: Now include phantom nodes
                //if (Int32.Parse(row["Size"].ToString()) != 0)
                //{
                    Transform(row["ContentId"].ToString(),
                        row["Metadata"].ToString(),
                        row["Annotations"].ToString(),
                        row["VersionId"].ToString(), 
                        row["Title"].ToString(),
                        contentDataSet);

                    XmlDocument document = new XmlDocument();

                    document.LoadXml(row["Metadata"].ToString());

                    XmlNamespaceManager nsManager = new XmlNamespaceManager(document.NameTable);
                    nsManager.AddNamespace("se", "urn:mtpg-com:mtps/2004/1/search");
                    nsManager.AddNamespace("xhtml", "http://www.w3.org/1999/xhtml");

                    XmlNodeList xmlNodes = document.SelectNodes("//xhtml:meta[@name='MSHKeywordK']/@content", nsManager);

                    foreach (XmlNode xmlNode in xmlNodes)
                    {
                        hhk.Add(xmlNode.InnerText, 
                            Path.Combine(chmSubDir, row["ContentId"].ToString() + ".htm"), 
                            row["Title"].ToString());
                    }
                //}
            }

            hhk.Save();

            int lcid = new CultureInfo(locale).LCID;
            

            // Create TOC
            Hhc hhc = new Hhc(Path.Combine(chmDir, baseName + ".hhc"), locale);
            CreateHhc(nodes, hhc, contentDataSet);
            hhc.Close();

            using (FileStream fileStream = new FileStream(Path.Combine(chmDir, baseName + ".hhp"),
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(template, chmFile, baseName, lcid, defaultPage, title);
                }
            }


            WriteExtraFiles();

            int numFiles = Directory.GetFiles(chmDir, "*", SearchOption.AllDirectories).Length;

            expectedLines = numFiles + 15;

        }



        // Compile() is called by a background Thread in ProgressForm so be carful

        void ICompilable.Compile(IProgressReporter progressReporter) 
        {
            this.progressReporter = progressReporter;

            // Use registry to find the compiler and invoke as a separate process.
            string key = @"HKEY_CURRENT_USER\Software\Microsoft\HTML Help Workshop";

            string install = (string)Registry.GetValue(key, "InstallDir", null);
            string hhcExe =  Path.Combine(install, "hhc.exe");

            if (install == null || File.Exists(hhcExe) == false)
            {
                throw (new Exception("Please install the HTML Help Workshop."));
            }
            
           
            
            Process compileProcess = new Process();

            compileProcess.StartInfo.FileName = "\"" + Path.Combine(install, "hhc.exe") + "\"";
            compileProcess.StartInfo.Arguments = "\"" + baseName + ".hhp" + "\"";                  //Fix: Wrap in quotes 
            compileProcess.StartInfo.CreateNoWindow = true;
            compileProcess.StartInfo.WorkingDirectory = chmDir;
            compileProcess.StartInfo.UseShellExecute = false;
            compileProcess.StartInfo.RedirectStandardOutput = true;
//            compileProcess.OutputDataReceived += new DataReceivedEventHandler(CompilerOutputHandler);

            
            
            compileProcess.Start();

            StreamReader streamReader = compileProcess.StandardOutput;

//            compileProcess.BeginOutputReadLine();
//            compileProcess.WaitForExit();

            string line;

            // The UI doesn't update because stdout isn't flushed, so for now, just toss
            // the message and call the progressReporter with the same
            // message.
            while(streamReader.EndOfStream != true)
            {
                line = streamReader.ReadLine();

                // if (String.IsNullOrEmpty(line) == false)
                {
                    progressReporter.ProgressMessage("Compiling");
                }
            }

            compileProcess.Close();

        }

        public void CreateHhc(TreeNodeCollection nodeCollection, Hhc hhc, Content contentDataSet)
        {
            bool opened = false; // Keep track of opening or closing of TOC entries

            foreach (TreeNode node in nodeCollection)
            {
                if (node.Checked == true)
                {
                    MtpsNode mtpsNode = node.Tag as MtpsNode;

                    DataRow row = contentDataSet.Tables["Item"].Rows.Find(mtpsNode.targetAssetId);
                    string Url;

                    //RWC: Now include phantom pages
                    //if (Int32.Parse(row["Size"].ToString()) == 0)
                    //    Url = null;
                    //else
                    //{
                        Url = Path.Combine(chmSubDir,
                            row["ContentId"].ToString() + ".htm");
                        
                        // Save the first page we see in the TOC as the default page as required
                        // by the chm.
                        if(defaultPage == null)
                            defaultPage = Url;
                    //}


                    hhc.WriteStartNode(mtpsNode.title, Url);

                    opened = true;
                }
                if (node.Nodes.Count != 0 || node.Tag != null)
                {
                    CreateHhc(node.Nodes, hhc, contentDataSet);
                }
                if (opened)
                {
                    opened = false;
                    hhc.WriteEndNode();
                }
            }

        }

        public void Transform(string contentId, string metadataXml, string annotationsXml,
            string versionId, string docTitle, Content contentDataSet)
        {
            XsltArgumentList arguments = new XsltArgumentList();
            Link link = new Link(contentDataSet, links);
            XmlDocument metadata = new XmlDocument();
            XmlDocument annotations = new XmlDocument();

            string filename = Path.Combine(withinChmDir, contentId + ".htm");

            string xml;
            if (File.Exists(filename))
            {
                StreamReader sr = new StreamReader(filename);
                xml = sr.ReadToEnd();
                sr.Close();
            }
            else  //Probably a node file that simply lists its children -- We will deal with this at a later date
            {
                xml = "<div class=\"topic\" xmlns=\"http://www.w3.org/1999/xhtml\">" + Environment.NewLine +
                      "  <div class=\"majorTitle\">" + docTitle + "</div>" + Environment.NewLine +
                      "  <div class=\"title\">" + docTitle + "</div>" + Environment.NewLine +
                      "  <div id=\"mainSection\">" + Environment.NewLine +
                      "    <div id=\"mainBody\">" + Environment.NewLine +
                      "      <p></p>" + Environment.NewLine +                //RWC: Too difficult to add child link list like MSDN Online. Just leave blank.
                      "    </div>" + Environment.NewLine +
                      "  </div>" + Environment.NewLine +
                      "</div>" + Environment.NewLine;
            }

            int codePage = new CultureInfo(locale).TextInfo.ANSICodePage;

            // We use these fallbacks because &nbsp; is unknown under DBCS like Japanese
            // and translated to ? by default.
            Encoding encoding = Encoding.GetEncoding(codePage,
                new EncoderReplacementFallback(" "),
                new DecoderReplacementFallback(" "));


            metadata.LoadXml(metadataXml);
            annotations.LoadXml(annotationsXml);

            arguments.AddParam("metadata", "", metadata.CreateNavigator());
            arguments.AddParam("annotations", "", annotations.CreateNavigator());
            arguments.AddParam("version", "", versionId);
            arguments.AddParam("locale", "", locale);
            arguments.AddParam("charset", "", encoding.WebName);

            arguments.AddExtensionObject("urn:Link", link);

            TextReader tr = new StringReader(xml);
            XmlReader xr = XmlReader.Create(tr);

            using (StreamWriter sw = new StreamWriter(filename, false, encoding))
            {
                try
                {
                    xform.Transform(xr, arguments, sw);

                }
                catch //(Exception ex)
                {
                    return;
                }
            }


        }


        private void CompilerOutputHandler(object sendingProcess, DataReceivedEventArgs message)
        {
            if (progressReporter != null)
            {
                progressReporter.ProgressMessage(message.Data);
            } 
        }


        // TODO: Factor the following as they are very similar to the .hxs equiv.

        // Includes stoplist and stylesheet
        void WriteExtraFiles()
        {
            WriteExtraFile("Classic.css");

            WriteExtraFile("green-left.jpg");
            WriteExtraFile("green-middle.jpg");
            WriteExtraFile("green-right.jpg");

        }

        void WriteExtraFile(string filename)
        {
            Stream resourceStream;

            resourceStream = typeof(Program).Assembly.GetManifestResourceStream(
                "PackageThis.Extra." + filename);

            FileStream fs = new FileStream(Path.Combine(chmDir, filename),
                FileMode.Create, FileAccess.Write);


            int b;

            while ((b = resourceStream.ReadByte()) != -1)
            {
                fs.WriteByte((byte)b);
            }

            resourceStream.Close();
            fs.Close();

        }

    }
}
