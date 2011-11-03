// Copyright (c) Microsoft Corporation.  All rights reserved.
//
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Reflection;
using PackageThis.MtpsFiles;
using System.Net;

namespace PackageThis
{
    class Mshc : ICompilable
    {

        //private bool Disposed;
        private string NewMshcDir;
        private string rawDir;
        private string VendorName;
        private string ProdName;
        private string BookName;
        private string MshcFile;
        private string packageName;
        private string locale;
        private Content contentDataSet;
        private TreeNodeCollection nodes;
        private Dictionary<string, string> links;

        private IProgressReporter progressReporter = null;

        //Set to "-1" to not create an artificial root node
        private String PackageThisRootID = "PackageThisRootID";   //The name "PackageThisRootID" is used by H3Viewer.exe so do not change (apart from to "-1")

        public int expectedLines = 1;

        static private Stream resourceStream = typeof(AppController).Assembly.GetManifestResourceStream("PackageThis.Extra.mshc.xslt");
        static private XmlReader transformFile = XmlReader.Create(resourceStream);
        static private XslCompiledTransform xform = null;

        private const string PackageRelationshipType = @"http://schemas.microsoft.com/opc/2006/sample/document";
        private const string ResourceRelationshipType = @"http://schemas.microsoft.com/opc/2006/sample/required-resource";




        public Mshc(string workingDir, string mshcFile, string locale, TreeNodeCollection nodes,
            Content contentDataSet, Dictionary<string, string> links, string VendorName, string ProdName, string BookName)
        {
            this.MshcFile = mshcFile;
            this.NewMshcDir = Path.GetDirectoryName(mshcFile);
            this.locale = locale;
            this.nodes = nodes;
            this.contentDataSet = contentDataSet;
            this.links = links;
            this.VendorName = VendorName;
            this.ProdName = ProdName;
            this.BookName = BookName;
            this.packageName = Path.GetFileNameWithoutExtension(this.MshcFile);
            this.expectedLines = contentDataSet.Tables["Item"].Rows.Count + 1;

            this.rawDir = Path.Combine(workingDir, "raw");

            if (xform == null)
            {
                xform = new XslCompiledTransform(true);
                xform.Load(transformFile);
            }
        }



        private string GetTocParent(TreeNodeCollection nodes, string currentAssetId)   
        {
            TreeNode n;
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    MtpsNode mtpsNode = node.Tag as MtpsNode;

                    DataRow row = contentDataSet.Tables["Item"].Rows.Find(mtpsNode.targetAssetId);

                    string assetId = row["AssetId"].ToString();

                    if (assetId == currentAssetId)   //found the row. Look up the tree node hierachie for a checked node and return ID
                    {
                        n = node;
                        while (n.Parent != null)
                        {
                            n = n.Parent;
                            if (n.Checked)
                            {
                                mtpsNode = n.Tag as MtpsNode;
                                row = contentDataSet.Tables["Item"].Rows.Find(mtpsNode.targetAssetId);
                                return row["AssetId"].ToString();
                            }
                        }
                        return "-1";
                    }
                }
                if (node.Nodes.Count > 0)
                {
                    string result = GetTocParent(node.Nodes, currentAssetId);   //recursive
                    if (result != "-1")
                        return result;
                }
            }
            return "-1";
        }



        public void MakeArtificialRootFile()
        {
            string filename = Path.Combine(rawDir, "PackageThisRoot.htm");
            if (File.Exists(filename))
                File.Delete(filename);

            try
            {
                StreamWriter writer = new StreamWriter(filename, true, System.Text.Encoding.UTF8);

                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                writer.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                writer.WriteLine("  <head>");
                writer.WriteLine("    <title>Package This</title>");
                writer.WriteLine("    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
                writer.WriteLine("    <meta name=\"save\" content=\"history\" />");
                writer.WriteLine("    <meta name=\"ROBOTS\" content=\"NOINDEX, NOFOLLOW\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.TopicLocale\" content=\"" + locale + "\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.Locale\" content=\"" + locale + "\" />");
                writer.WriteLine("    <meta name=\"Language\" content=\"" + locale + "\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.Package\" content=\"PackageThis\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.Id\" content=\"" + PackageThisRootID + "\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.F1\" content=\"PackageThis\" />");
                writer.WriteLine("    <meta name=\"System.Keywords\" content=\"Package This\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.TocParent\" content=\"-1\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.TocOrder\" content=\"1\" />");
                writer.WriteLine("    <meta name=\"Microsoft.Help.TopicVersion\" content=\"100\" />");
                writer.WriteLine("    <meta name=\"SelfBranded\" content=\"false\" />");
                writer.WriteLine("  </head>");
                writer.WriteLine("  <body>");
                writer.WriteLine("    <div class=\"Package This\" xmlns=\"\">");
                writer.WriteLine("      <!--*-->");
                writer.WriteLine("    </div>");
                writer.WriteLine("    <div class=\"title\" xmlns=\"\">Package This</div>");
                writer.WriteLine("    <div id=\"mainSection\" xmlns=\"\">");
                writer.WriteLine("      <div id=\"mainBody\">");
                writer.WriteLine("          <p>PackageThis Web site: <a href=\"http://packagethis.codeplex.com/\" target=\"_blank\">packagethis.codeplex.com</a></p>");
                writer.WriteLine("          <p>Produced by PackageThis Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "</p>");
                writer.WriteLine("      </div>");
                writer.WriteLine("    </div>");
                writer.WriteLine("  </body>");
                writer.WriteLine("</html>");

                writer.Flush();
                // Free resources
                writer.Close();
                writer = null;
                GC.SuppressFinalize(this);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Compile() is called by a background Thread in ProgressForm so be carful

        void ICompilable.Compile(IProgressReporter progressReporter)  //Called by Progress form
        {
            this.progressReporter = progressReporter;
            Create();
        }

        private void Create()
        {
            Directory.CreateDirectory(NewMshcDir);

            this.progressReporter.ProgressMessage("!Creating all files...");   // ! = Reset progress bar

            int n = 1;
            foreach (DataRow row in contentDataSet.Tables["Item"].Rows)
            {
                this.progressReporter.ProgressMessage("*");   // * increment progress only

                //if (Int32.Parse(row["Size"].ToString()) != 0)
                {
                    string tocParent = GetTocParent(nodes, row["AssetId"].ToString());
                    if (tocParent == "-1")
                        tocParent = PackageThisRootID;

                    if (DownloadMtps.DownloadOfflineFileAndSave(
                        row["ContentId"].ToString(),
                        row["AssetId"].ToString(),
                        row["VersionId"].ToString(),
                        tocParent,
                        n.ToString(),
                        this.rawDir,
                        this.locale,
                        this.packageName
                        ))                         // toc order
                    {
                           //Downloaded and saved successfully!
                    }
                    else   //Need to create the files in the normal way - Not as good. It will have to do.
                    {
                        Transform(
                            row["ContentId"].ToString(),           // filename = shortid
                            row["AssetId"].ToString(),             // id
                            row["Metadata"].ToString(),
                            row["Annotations"].ToString(),
                            row["VersionId"].ToString(),           // eg. vs.100 
                            row["Title"].ToString(),
                            tocParent,                             // toc parent ID
                            n.ToString(),                          // toc order
                            contentDataSet);
                    }

                    n = n + 1;
                }
            }

            //====================================== Zip It!

            if (File.Exists(this.MshcFile))
                File.Delete(this.MshcFile);


            this.progressReporter.ProgressMessage("!Compressing files...");   // ! = Reset progress bar

            // Create artificial super parent

            if (PackageThisRootID != "-1")
                MakeArtificialRootFile();

            // Zip all to .mshc file

            using (Package package = Package.Open(this.MshcFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                foreach (string file in Directory.GetFiles(rawDir))
                {
                    this.progressReporter.ProgressMessage("*");   // * increment progress only

                    FileInfo fileInfo = new FileInfo(file);
                    string fileType = (fileInfo.Extension.ToUpper());
                    string newDocPath = file;
                    string documentPath = Path.Combine(rawDir, Path.GetFileName(file));

                    {
                        if (fileType == ".HTM" || fileType == ".HTML")
                        {
                            Uri partUriDocument = PackUriHelper.CreatePartUri(new Uri(Path.GetFileName(file), UriKind.Relative));
                            // Add a Resource Part to the Package
                            PackagePart packagePartDocument = package.CreatePart(partUriDocument, System.Net.Mime.MediaTypeNames.Text.Html);
                            // Copy the data to the Document Part
                            using (FileStream fileStream = new FileStream(documentPath, FileMode.Open, FileAccess.Read))
                            {
                                CopyStream(fileStream, packagePartDocument.GetStream());
                            }// end:using(fileStream) - Close and dispose fileStream.
                            // Add a Package Relationship to the Document Part
                            package.CreateRelationship(packagePartDocument.Uri, TargetMode.Internal, PackageRelationshipType);
                        }

                        if (fileType == ".GIF")
                        {
                            Uri partUriResource = PackUriHelper.CreatePartUri(new Uri(Path.GetFileName(file), UriKind.Relative));
                            PackagePart packagePartResource = package.CreatePart(partUriResource, System.Net.Mime.MediaTypeNames.Image.Gif);

                            // Copy the data to the Resource Part
                            using (FileStream fileStream = new FileStream(documentPath, FileMode.Open, FileAccess.Read))
                            {
                                CopyStream(fileStream, packagePartResource.GetStream());
                            }// end:using(fileStream) - Close and dispose fileStream.

                        }
                        if (fileType == ".PNG")
                        {
                            Uri partUriResource = PackUriHelper.CreatePartUri(new Uri(Path.GetFileName(file), UriKind.Relative));
                            PackagePart packagePartResource = package.CreatePart(partUriResource, System.Net.Mime.MediaTypeNames.Image.Gif);

                            // Copy the data to the Resource Part
                            using (FileStream fileStream = new FileStream(documentPath, FileMode.Open, FileAccess.Read))
                            {
                                CopyStream(fileStream, packagePartResource.GetStream());
                            }// end:using(fileStream) - Close and dispose fileStream.

                        }
                        if (fileType == ".JPG")
                        {
                            Uri partUriResource = PackUriHelper.CreatePartUri(new Uri(Path.GetFileName(file), UriKind.Relative));
                            PackagePart packagePartResource = package.CreatePart(partUriResource, System.Net.Mime.MediaTypeNames.Image.Jpeg);

                            // Copy the data to the Resource Part
                            using (FileStream fileStream = new FileStream(documentPath, FileMode.Open, FileAccess.Read))
                            {
                                CopyStream(fileStream, packagePartResource.GetStream());
                            }// end:using(fileStream) - Close and dispose fileStream.

                        }
                        if (fileType == ".TIFF")
                        {
                            Uri partUriResource = PackUriHelper.CreatePartUri(new Uri(Path.GetFileName(file), UriKind.Relative));
                            PackagePart packagePartResource = package.CreatePart(partUriResource, System.Net.Mime.MediaTypeNames.Image.Tiff);

                            // Copy the data to the Resource Part
                            using (FileStream fileStream = new FileStream(documentPath, FileMode.Open, FileAccess.Read))
                            {
                                CopyStream(fileStream, packagePartResource.GetStream());
                            }// end:using(fileStream) - Close and dispose fileStream.

                        }
                    }
                }
            }// end:using (Package package) - Close and dispose package.


            // Write .MSHA
            WriteHelpContentSetup();
        }



        //  --------------------------- CopyStream ---------------------------
        /// <summary>
        ///   Copies data from a source stream to a target stream.</summary>
        /// <param name="source">
        ///   The source stream to copy from.</param>
        /// <param name="target">
        ///   The destination stream to copy to.</param>
        private static void CopyStream(Stream source, Stream target)
        {
            const int bufSize = 0x1000;
            byte[] buf = new byte[bufSize];
            int bytesRead = 0;
            while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)
                target.Write(buf, 0, bytesRead);
        }// end:CopyStream()

        void WriteHelpContentSetup()
        {
            
            int codePage = new CultureInfo(locale).TextInfo.ANSICodePage;
            Encoding encoding = Encoding.GetEncoding(codePage);
            string VN = this.VendorName;
            string PN = this.ProdName;
            string BN = this.BookName;

            if (VN.Equals("Microsoft", StringComparison.OrdinalIgnoreCase))   //rwc: "Microsoft" will cause install to fail (MS expect a CAB install)
            {
                VN = "Microsoft_PackageThis";
            }
            if (VN.Length <= 1)
            { 
                VN = "PackageThis2";
            }
            if (PN.Length <= 1)
            {
                PN = "PackageThis2";
            }
            if (BN.Length <= 1)
            {
                BN = "PackageThis2";
            }

            string metaFile = Path.Combine(NewMshcDir, "HelpContentSetup.msha");
            if (File.Exists(metaFile))
                File.Delete(metaFile);

            try
            {
                StreamWriter writer = new StreamWriter(metaFile, true, System.Text.Encoding.UTF8);

                writer.WriteLine("<html xmlns=\""+"http://www.w3.org/1999/xhtml"+"\">");

                writer.WriteLine("<head />");
                writer.WriteLine("<body class=\"vendor-book\">");
                writer.WriteLine("<div class=\"details\">");

                writer.WriteLine("  <span class=\"vendor\">" + VN + "</span>");
                writer.WriteLine("  <span class=\"locale\">en-us</span>");
                writer.WriteLine("  <span class=\"product\">" + PN + "</span>");

                writer.WriteLine("  <span class=\"name\">" + BN + "</span>");
                writer.WriteLine("</div>");
                writer.WriteLine("<div class=\"package-list\">");
                writer.WriteLine("  <div class=\"package\">");


                writer.WriteLine("    <span class=\"name\">" + this.packageName + "</span>");
                writer.WriteLine("    <span class=\"deployed\">true</span>");
                writer.WriteLine("    <a class=\"current-link\" href=\"" + this.packageName + ".mshc\">" + this.packageName + ".mshc</a>");
                writer.WriteLine("  </div>");
                writer.WriteLine("</div>");

                writer.WriteLine("</body>");
                writer.WriteLine("</html>");

                writer.Flush();
                // Free resources
                writer.Close();
                writer = null;
                GC.SuppressFinalize(this);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public void Transform(string contentId, string assetId, string metadataXml, string annotationsXml,
            string versionId, string docTitle, string tocParent, string tocOrder, Content contentDataSet)
        {
            XsltArgumentList arguments = new XsltArgumentList();
            Link link = new Link(contentDataSet, links);
            XmlDocument metadata = new XmlDocument();
            XmlDocument annotations = new XmlDocument();

            string filename = Path.Combine(rawDir, contentId + ".htm");

            string xml2;
            if (File.Exists(filename))
            {
                StreamReader sr2 = new StreamReader(filename);
                xml2 = sr2.ReadToEnd();
                sr2.Close();
            }
            else  //Probably a node file that simply lists its children -- We will deal with this at a later date
            {
                xml2 = "<div class=\"topic\" xmlns=\"http://www.w3.org/1999/xhtml\">"+ 
                       "  <div class=\"majorTitle\">" + docTitle + "</div>" +
                       "  <div class=\"title\">" + docTitle + "</div>" + 
                       "  <div id=\"mainSection\">" + 
                       "    <div id=\"mainBody\">" + 
                       "      <p></p>" +                //RWC: Too difficult to add child link list like MSDN Online. Just leave blank.
                       "    </div>" + 
                       "  </div>" + 
                       "</div>"; 
            }

            int codePage = new CultureInfo(locale).TextInfo.ANSICodePage;

            string topicVersion = versionId;
            int idx = versionId.LastIndexOf('.');
            if (idx >= 0)
              topicVersion = versionId.Substring(idx+1);     //we want the 100 from vs.100

            // We use these fallbacks because &nbsp; is unknown under DBCS like Japanese
            // and translated to ? by default.
            Encoding encoding = Encoding.GetEncoding(codePage,
                new EncoderReplacementFallback(" "),
                new DecoderReplacementFallback(" "));

            metadata.LoadXml(metadataXml);
            annotations.LoadXml(annotationsXml);

            arguments.AddParam("metadata", "", metadata.CreateNavigator());
            arguments.AddParam("annotations", "", annotations.CreateNavigator());
            arguments.AddParam("assetId", "", assetId);
            arguments.AddParam("version", "", versionId);
            arguments.AddParam("tocOrder", "", tocOrder);
            arguments.AddParam("tocParent", "", tocParent);
            arguments.AddParam("locale", "", locale);
            arguments.AddParam("charset", "", encoding.WebName);
            arguments.AddParam("package", "", packageName);
            arguments.AddParam("topicVersion", "", topicVersion);

            arguments.AddExtensionObject("urn:Link", link);

            TextReader tr2 = new StringReader(xml2);
            XmlReader xr2 = XmlReader.Create(tr2);

            using (StreamWriter sw2 = new StreamWriter(filename, false, System.Text.Encoding.UTF8))
            {
                try
                {
                    xform.Transform(xr2, arguments, sw2);

                }
                catch (Exception ex)
                {
                    return;
                }
            }

        }
    }


    public static class DownloadMtps
    {
        private static String rawDir;

        /* 
         * We get a pre-formated offline version from the mtps system. Return true if successful.
         * 
         * A typical formatted file....
         * 
            <html xmlns="http://www.w3.org/1999/xhtml"> 
              <head> 
                <meta name="ROBOTS" content="NOINDEX, NOFOLLOW" /> 
                <meta http-equiv="Content-Location" content="http://services.mtps.microsoft.com/serviceapi/content/cc295789/en-us;expression.10/primary/mtps.offline" /> 
                <title>Design Tools</title> 
                <link rel="parent" href="../../../../../serviceapi/content/cc295789/en-us;expression.10" /> 
                <meta name="Microsoft.Help.TopicLocale" content="en-us" /> 
                <meta name="Microsoft.Help.TopicVersion" content="10" /> 
                <meta name="SelfBranded" content="false" /> 
                <meta name="Microsoft.Help.Locale" content="en-us" /> 
                <meta name="Title" content="Design Tools" /> 
          
                <meta name="Microsoft.Help.Id" content="Expression|DesignToolsTech|$\designtoolstech.hxt@0,0" /> 
                <meta name="Microsoft.Help.TocParent" content="N:System.Xml" /> 
                <meta name="Microsoft.Help.TocOrder" content="0" />          
                <meta name="Microsoft.Help.Package" content="Visual_Studio_21800791_VS_100_en-us_6" />
              </head> 
              ....  
         *  
         */
        public static Boolean DownloadOfflineFileAndSave(string contentId, string assetId, string versionId, string tocParent, 
            string tocOrder, string rawdir_, string locale, string packageName)
        {
            rawDir = rawdir_;

            //Special mtps service that transforms online content to full offline file
            //If successful we just need to save it.
            //http://services.mtps.microsoft.com/serviceapi/content/cc295789/en-us;expression.10/primary/mtps.offline

            string filename = Path.Combine(rawDir, contentId + ".htm");

            String url = String.Format("http://services.mtps.microsoft.com/serviceapi/content/{0}/{1};{2}/primary/mtps.offline",
                    contentId, locale, versionId);

            // already downloaded? The formated file starts with <?xml version="1.0" encoding="utf-8"?><html > .. <html>,
            // while the original file start with <div> (a file fragment)

            if (File.Exists(filename))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(filename);
                XmlElement xe = xml.DocumentElement;
                if (xe != null && xe.Name == "html")
                    return true;                          //We already downloaded the file 
            }


            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Downloading the doc -- Modify and save as file
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            try
            {
                WebRequest request = WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream fileStream = request.GetResponse().GetResponseStream())
                    {
                        if (fileStream == null)   //failed to load
                            return false;

                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.Load(fileStream);

                        //Find <head> section (should be 1 only))

                        XmlNodeList headNodes = xmldoc.GetElementsByTagName("head");
                        if (headNodes == null || headNodes.Count != 1)
                            return false;

                        //Find these meta tags in <head> section

                        XmlNode nodeId = null;
                        XmlNode nodeTocParent = null;
                        XmlNode nodeTocOrder = null;
                        XmlNode nodePackage = null;

                        foreach (XmlNode node in headNodes[0].ChildNodes)
                        {
                            if (node.Name == "meta" && node.Attributes.Count >= 2)
                            {
                                //Console.WriteLine(node.Value + " > " + node.Attributes[0].Name + "=" + node.Attributes[0].Value + "; "
                                //     + node.Attributes[1].Name + "=" + node.Attributes[1].Value);

                                if (node.Attributes[0].Value == "Microsoft.Help.Id")
                                    nodeId = node;
                                else if (node.Attributes[0].Value == "Microsoft.Help.TocParent")
                                    nodeTocParent = node;
                                else if (node.Attributes[0].Value == "Microsoft.Help.TocOrder")
                                    nodeTocOrder = node;
                                else if (node.Attributes[0].Value == "Microsoft.Help.Package")
                                    nodePackage = node;
                            }
                        }

                        if (nodeId == null)  //unlikely -- There should always be an ID 
                            return false;

                        // Mods...

                        // Make sure the Microsoft.Help.Id is correct 

                        XmlElement elem = xmldoc.CreateElement("meta", xmldoc.DocumentElement.NamespaceURI);   //add root element NamespaceUri to suppress unwanted xmlns="" attribute
                        elem.SetAttribute("name", "Microsoft.Help.Id");
                        elem.SetAttribute("content", assetId);
                        headNodes[0].ReplaceChild(elem, nodeId);

                        // Add or Replace TocParent meta tag <meta name="Microsoft.Help.TocParent" content="xxxxx" /> 

                        elem = xmldoc.CreateElement("meta", xmldoc.DocumentElement.NamespaceURI);
                        elem.SetAttribute("name", "Microsoft.Help.TocParent");
                        elem.SetAttribute("content", tocParent);
                        if (nodeTocParent == null)
                            nodeTocParent = headNodes[0].AppendChild(elem);
                        else
                            headNodes[0].ReplaceChild(elem, nodeTocParent);

                        // Add or Replace TocOrder meta tag <meta name="Microsoft.Help.TocOrder" content="0" /> 

                        elem = xmldoc.CreateElement("meta", xmldoc.DocumentElement.NamespaceURI);
                        elem.SetAttribute("name", "Microsoft.Help.TocOrder");
                        elem.SetAttribute("content", tocOrder);
                        if (nodeTocOrder == null)
                            nodeTocOrder = headNodes[0].AppendChild(elem);
                        else
                            headNodes[0].ReplaceChild(elem, nodeTocOrder);

                        // Add a package name meta tag (nice to have) <meta name="Microsoft.Help.Package" content="Visual_Studio_21800791_VS_100_en-us_6" />

                        elem = xmldoc.CreateElement("meta", xmldoc.DocumentElement.NamespaceURI);
                        elem.SetAttribute("name", "Microsoft.Help.Package");
                        elem.SetAttribute("content", packageName);
                        if (nodePackage == null)
                            nodePackage = headNodes[0].AppendChild(elem);
                        else
                            headNodes[0].ReplaceChild(elem, nodePackage);



                        // Fix image links <img src= > -- Guarenteed they will be wrong
                        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                        // Sometimes <img alt="xx" contains the real filename. 
                        //      <img class="mtps-img-src" alt="Ee504799.13adbc76-a74f-4f79-af36-1db59b5d8711(en-US,WinEmbedded.60).gif" src="IC79442" />
                        //      <img class="mtps-img-src" alt="..\local\68fc1494-758d-4923-a87d-c8a1daec9220.png" src="IC79442" />
                        // Sometimes the real name is in the preceeding comment
                        //      <!--src=[..\local\68fc1494-758d-4923-a87d-c8a1daec9220.png]-->
                        //      <img class="mtps-img-src" alt="The toolbox" src="IC411623" />
                        // Sometime we have a partial filename we need to expand
                        //      <img class="mtps-img-src" alt="Screen shot of a taskbar  " src="visind27.png" />
                        //      needs to be expanded to bb328626.visind27(en-us,MSDN.10).png


                        XmlNodeList imgNodes = xmldoc.GetElementsByTagName("img");
                        //Console.WriteLine("imgNodes.Count=" + imgNodes.Count);
                        foreach (XmlNode node in imgNodes)
                        {
                            if (node == null || node.Name != "img" || node.Attributes.Count < 2)
                                continue;

                            /*Console.WriteLine();
                            Console.WriteLine(node.Value + " > " + node.Attributes[0].Name + "=" + node.Attributes[0].Value + "; "
                                       + node.Attributes[1].Name + "=" + node.Attributes[1].Value);*/

                            string altValue = "";
                            string srcValue = "";
                            string cmtValue = "";
                            String result = "";
                            int iSrc = -1;

                            // find alt= and src= position

                            for (int i = 0; i < node.Attributes.Count; i++)
                            {
                                if (node.Attributes[i].Name == "alt")                // alt= value
                                    altValue = Path.GetFileName(node.Attributes[i].Value);
                                else if (node.Attributes[i].Name == "src")
                                    iSrc = i;                                        //record where the imgName should go
                            }

                            // src= not found (unlikely)

                            if (iSrc < 0)
                                continue;
                            srcValue = Path.GetFileName(node.Attributes[iSrc].Value);

                            //Console.WriteLine("srcValue=" + srcValue);

                            // Value from previous comment <!--src=[..\local\imageFilePath.png]-->

                            XmlNode lastNode = node.PreviousSibling;
                            if (lastNode != null && lastNode.NodeType == XmlNodeType.Comment)
                            {
                                String s = lastNode.Value;              // src=[./imageFilePath.gif]
                                if (s.Substring(0, 5) == "src=[")
                                    cmtValue = Path.GetFileName(s.Substring(5, s.Length - 6));   // imageFilePath.gif
                            }

                            //Console.WriteLine("cmtValue=" + cmtValue);

                            // Search for the actual filename - start off looking for exact match then widen the match parameters

                            for (int validateLevel = 1; validateLevel <= 3; validateLevel++)
                            {
                                result = ValidateImgFilename(srcValue, contentId, validateLevel);
                                if (result != "")
                                    break;
                                result = ValidateImgFilename(altValue, contentId, validateLevel);
                                if (result != "")
                                    break;
                                result = ValidateImgFilename(cmtValue, contentId, validateLevel);
                                if (result != "")
                                    break;
                            }

                            // sigh! No image filename - Can probably find it in the downloaded .htm file (downloaded when we check TOC node)
                            //Console.WriteLine("result1=" + result);

                            if (result == "" && File.Exists(filename))
                            {
                                XmlDocument xmldoc2 = new XmlDocument();
                                xmldoc2.Load(filename);
                                XmlNodeList imgNodes2 = xmldoc2.GetElementsByTagName("img");

                                foreach (XmlNode node2 in imgNodes2)  // for all image nodes
                                {
                                    if (node2 == null || node2.Name != "img" || node2.Attributes.Count < 2)
                                        continue;

                                    string altValue2 = node2.Attributes["alt"].Value;
                                    if (altValue2 == altValue)
                                    {
                                        String srcVal = node2.Attributes["src"].Value;
                                        for (int iLevel = 1; iLevel <= 3; iLevel++)
                                        {
                                            result = ValidateImgFilename(srcVal, contentId, iLevel);
                                            if (result != "")
                                                break;
                                        }
                                    }
                                    if (result != "")
                                        break;
                                }
                            }

                            //Console.WriteLine("result2=" + result);
/*
                            // Still not found? Take the first image file we find
                            if (result == "")
                            {
                                string[] files = System.IO.Directory.GetFiles(rawDir, contentId + ".*.gif");
                                if (files.Length == 0)
                                    files = System.IO.Directory.GetFiles(rawDir, contentId + ".*.png");
                                if (files.Length == 0)
                                    files = System.IO.Directory.GetFiles(rawDir, contentId + ".*.jpg");
                                if (files.Length > 0)
                                    result = Path.GetFileName(files[0]);   //file found
                            }
*/
                            // Done! Update the <img src=
                            if (result != "")
                                node.Attributes[iSrc].Value = result;
                        }  // for each <img>

                        //Save the file
                        xmldoc.Save(filename);

                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        private static String ValidateImgFilename(String link, String contentId, int valLevel)
        {
            try
            {
                /*Console.WriteLine("  link=" + link);
                Console.WriteLine("  contentId=" + contentId);
                Console.WriteLine("  validateLevel=" + valLevel);*/

                if (link.Length != 0)
                {
                    string[] files;
                    String linkNoExt;

                    if (valLevel == 1)  //look for exact match
                    {
                        files = System.IO.Directory.GetFiles(rawDir, link);
                        if (files.Length > 0)
                            return Path.GetFileName(files[0]);   //file found
                    }

                    if (valLevel == 2)  //look contentId.link?????.??? match
                    {
                        linkNoExt = Path.GetFileNameWithoutExtension(link);
                        files = System.IO.Directory.GetFiles(rawDir, contentId + "." + linkNoExt + "*");
                        if (files.Length > 0)
                            return Path.GetFileName(files[0]);   //file found
                    }

                    if (valLevel == 3)  //look ????link?????.??? match
                    {
                        linkNoExt = Path.GetFileNameWithoutExtension(link);
                        files = System.IO.Directory.GetFiles(rawDir, "*" + linkNoExt + "*");
                        if (files.Length > 0)
                            return Path.GetFileName(files[0]);   //file found
                    }
                }
            }
            catch
            {
                return "";  // file not found
            }
            
            return "";  // file not found
        }
   }
}
