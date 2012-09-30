#define __NODE_DATA_DEBUG

// Copyright (c) Microsoft Corporation.  All rights reserved.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Web;
using System.Windows.Forms;
using MSHelpCompiler;
using ContentServiceLibrary;
using PackageThis.MtpsFiles;
using System.Diagnostics;
using MiscFuncs;

// Version variables in this code are collection + "." + version, but ContentItem requires a
// version and collection, eg. version="10", collection="MSDN"

namespace PackageThis
{
    public class MtpsNode
    {
        public string navAssetId;
        public string navLocale;
        public string navVersion;

        public string targetAssetId;
        public string targetContentId;
        public string targetLocale;
        public string targetVersion;

        public string title;

        public bool external;


        public MtpsNode(string navAssetId, string navLocale, string navVersion,
            string targetContentId, string targetAssetId, string targetLocale, 
            string targetVersion, string title)
        {
            this.navAssetId = navAssetId;
            this.navLocale = navLocale;
            this.navVersion = navVersion;

            this.targetContentId = targetContentId;

            this.targetAssetId = targetAssetId.ToLower().StartsWith("assetid:") == true ?
                targetAssetId.Remove(0,8) : targetAssetId;

            this.targetLocale = targetLocale;
            this.targetVersion = targetVersion;
            

            this.title = title;

            this.external = targetAssetId.ToLower().Contains("http:");
        }

    }

    public class AppController
    {
        private string application = "PackageThisGui";
        private string topNode;
        private string locale;
        private string version;
        private TreeView tocControl;

        private string workingDir;
        private string rawDir;

        //These set by main form
        public RichTextBoxFuncs _rtDebug = null;
        public TabControl _tabControl = null;
        public TabPage _tabPage_Debug = null;
        public TabPage _tabPage_List = null;

        private int exceptionCount = 0;

        // static private StreamWriter sw;

        public Dictionary<string, string> links = new Dictionary<string, string>();

        public AppController(string topNode, string locale, string version, TreeView tocControl, string workingDir)
        {
            this.topNode = topNode;
            this.locale = locale;
            this.version = version;
            this.tocControl = tocControl;

            this.workingDir = workingDir;
            this.rawDir = Path.Combine(workingDir, "raw");

            Directory.CreateDirectory(rawDir);

            ContentItem contentItem = lookupTOCNode(topNode, locale, version);

            processNodeList(contentItem, tocControl.Nodes);
        }

        ContentItem lookupTOCNode(string contentIdentifier, string locale, string version)
        {
            string[] splitVersion = version.Split(new char[] {'.'});

            ContentItem contentItem = new ContentItem(contentIdentifier, locale, splitVersion[1], 
                splitVersion[0], application);
            contentItem.Load(false, false);

            return contentItem;
        }
        

        void processNodeList(ContentItem contentItem, TreeNodeCollection tnCollection)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNamespaceManager nsm = new XmlNamespaceManager(xmlDocument.NameTable);
            nsm.AddNamespace("toc", "urn:mtpg-com:mtps/2004/1/toc");
            nsm.AddNamespace("mtps", "http://msdn2.microsoft.com/mtps");
            nsm.AddNamespace("asp", "http://msdn2.microsoft.com/asp");
            nsm.AddNamespace("mshelp", "http:/msdn.microsoft.com/mshelp");

            if(string.IsNullOrEmpty(contentItem.toc) == true)
                return;

            xmlDocument.LoadXml(contentItem.toc);

            XmlNodeList nodes = xmlDocument.SelectNodes("/toc:Node/toc:Node", nsm);


            foreach(XmlNode node in nodes)
            {
                string title = GetAttribute(node.Attributes["toc:Title"]);

                string target = HttpUtility.UrlDecode(GetAttribute(node.Attributes["toc:Target"]));

                string targetLocale = GetAttribute(node.Attributes["toc:TargetLocale"]);
                string targetVersion = GetAttribute(node.Attributes["toc:TargetVersion"]);

                string subTree = HttpUtility.UrlDecode(GetAttribute(node.Attributes["toc:SubTree"]));
                string subTreeVersion = GetAttribute(node.Attributes["toc:SubTreeVersion"]);
                string subTreeLocale = GetAttribute(node.Attributes["toc:SubTreeLocale"]);
                string isPhantom = GetAttribute(node.Attributes["toc:IsPhantom"]);

                if (isPhantom != "true" && 
                    title != "@PhantomNode" &&
                    title != "@NoTitle" &&
                    string.IsNullOrEmpty(title) != true &&
                    string.IsNullOrEmpty(target) != true)
                {
                    TreeNode treeNode = tnCollection.Add(title);

                    MtpsNode mtpsNode = new MtpsNode(subTree, subTreeLocale, subTreeVersion,
                        contentItem.contentId, target, targetLocale, targetVersion, title);

                    treeNode.Tag = mtpsNode;

#if (NODE_DATA_DEBUG)
                    //Is the Asset a GUID?  *-xxxx-xxxx-xxxx-*
                    string[] split = target.Split(new char[] { '-' });
                    if (split.Length == 5 && split[1].Length == 4 && split[2].Length == 4 && split[3].Length == 4)
                    {
                        treeNode.Text = treeNode.Text + "(GUID)";
                        treeNode.ForeColor = System.Drawing.Color.Blue;
                    }

                    treeNode.Text = treeNode.Text + "(" + targetVersion + "/" + targetLocale + ")";
#endif

                    // Mark nodes red that point outside this server
                    if (mtpsNode.external == true)
                    {
                        treeNode.ForeColor = System.Drawing.Color.Red;

                        //treeNode.NodeFont = new System.Drawing.Font(tocControl.Font, System.Drawing.FontStyle.Italic);
                    }


                    if (subTree != null)
                    {
                        // Add a + as the title so any node with subnodes is expandable.
                        // Only load the subnodes when user expands this node.
                        // We rely on Tag == null rather than Text == "+" in case
                        // there really is a node with a title of "+".
                        treeNode.Nodes.Add("+");

                    }
                }
                else
                {
                    if (subTree != null)
                    {
                        // TODO: add a ContentItem constructor that takes a combined 
                        // version string: MSDN.10, Office.12, etc.

                        string[] splitVersion = subTreeVersion.Split(new char[] {'.'});
                        ContentItem childContentItem = new ContentItem(subTree, subTreeLocale, 
                            splitVersion[1], splitVersion[0], application);
                        childContentItem.Load(false);

                        processNodeList(childContentItem, tnCollection);
                    }
                }
            }

        }



        private string GetAttribute(XmlAttribute attribute)
        {
            return (attribute == null ? null : attribute.Value);
        }

        public void ExpandNode(TreeNode node)
        {
            if (node.Nodes[0].Tag == null)
            {
                ContentItem contentItem;
                MtpsNode mtpsNode = node.Tag as MtpsNode;

                try
                {
                    contentItem = lookupTOCNode(mtpsNode.navAssetId, mtpsNode.navLocale,
                        mtpsNode.navVersion);
                    processNodeList(contentItem, node.Nodes);
 
                }
                catch
                {
//                    mtpsNode.external = true;
//                    node.ForeColor = System.Drawing.Color.Red;
                }
                
                node.Nodes.Remove(node.Nodes[0]); // This removes the node labeled "+"
            }
        }


        public void UncheckNodes(TreeNode node)
        {

            // Events are created even if the checked state doesn't change.
            // That confuses the event handler because it assumes that the
            // event is only fired on a state change.


            if(node.Checked == true)
                node.Checked = false;

            foreach (TreeNode currentNode in node.Nodes)
            {
                if(currentNode.Checked == true)
                    currentNode.Checked = false;

                if (currentNode.Nodes != null)
                    UncheckNodes(currentNode);
            }
        }


        public String GetDocShortId(TreeNode node)   //use this when the short id is missing
        {
            MtpsNode mtpsNode = node.Tag as MtpsNode;

            // RWC: Inherited this system with some weird bugs. Sometimes a valid node can return a null contentId
            // Often in these situations the AssetId is Content GUID which can be used to pull down an mtps file and parse for the short id

            string[] split = mtpsNode.targetAssetId.Split(new char[] { '-' });
            if (split.Length == 5 && split[1].Length == 4 && split[2].Length == 4 && split[3].Length == 4)  //it's a guid format we can look this up
            {
                MtpsFile.ReadData(mtpsNode.targetAssetId, mtpsNode.targetVersion, mtpsNode.targetLocale);   //download mtps file and grab shortId
                if (MtpsFile.shortId != "")
                    return MtpsFile.shortId;
            }

            // Try the tradition method

            string[] splitVersion = mtpsNode.targetVersion.Split(new char[] { '.' });
            ContentItem contentItem = new ContentItem("AssetId:" + mtpsNode.targetAssetId, mtpsNode.targetLocale,
                splitVersion[1], splitVersion[0], application);
            try
            {
                contentItem.Load(true);
            }
            catch
            {
            }

            if (contentItem.contentId == null)
                contentItem.contentId = "";
            return contentItem.contentId;
        }


        public bool WriteContent(TreeNode node, Content contentDataSet)
        {
            DataRow row;
            MtpsNode mtpsNode = node.Tag as MtpsNode;
            ContentItem contentItem = null;
            
            string[] splitVersion = mtpsNode.targetVersion.Split(new char[] {'.'});
            string sdebug = "";


            try
            {
                sdebug = "z0";
                contentItem = new ContentItem("AssetId:" + mtpsNode.targetAssetId, mtpsNode.targetLocale,
                    splitVersion[1], splitVersion[0], application);

                try
                {
                    sdebug = "z1";
                    contentItem.Load(true);
                    sdebug = "z2";

                    // RWC: This is a HACK -- There are a few pages where the ContentId returns as null even though it's a valid page
                    //
                    if (String.IsNullOrEmpty(contentItem.contentId))
                    {
                        contentItem.contentId = GetDocShortId(node);
                    }
                    sdebug = "z3";
                }

                catch
                {
                    node.ForeColor = System.Drawing.Color.Red;
                    return false; // tell the event handler to reject the click.
                }

                sdebug = "z4";
                if (contentDataSet.Tables["Item"].Rows.Find(mtpsNode.targetAssetId) == null)
                {
                    sdebug = "z5";
                    //Issue#14155: Sometimes there can be missing values that cause exceptions. 
                    //Lets's try and bluff our way through
                    if (string.IsNullOrEmpty(contentItem.contentId))
                    {
                        sdebug = "z6";
                        node.ForeColor = System.Drawing.Color.Red;   //Set tree node red to flag problem
                        contentItem.contentId = "PackageThis-" + mtpsNode.targetAssetId;  //Create a repeatable ID using the Asset ID
                    }
                    sdebug = "z7";
                    // If we get no meta/search or wiki data, plug in NOP data so we can limp along (this usually comes with null contentId above)
                    if (string.IsNullOrEmpty(contentItem.metadata))
                        contentItem.metadata = "<se:search xmlns:se=\"urn:mtpg-com:mtps/2004/1/search\" />";
                    if (string.IsNullOrEmpty(contentItem.annotations))
                        contentItem.annotations = "<an:annotations xmlns:an=\"urn:mtpg-com:mtps/2007/1/annotations\" />";
                    sdebug = "z8";

                    row = contentDataSet.Tables["Item"].NewRow();
                    row["ContentId"] = contentItem.contentId;
                    row["Title"] = mtpsNode.title;
                    row["VersionId"] = mtpsNode.targetVersion;
                    row["AssetId"] = mtpsNode.targetAssetId;
                    row["Pictures"] = contentItem.numImages;
                    row["Size"] = contentItem.xml == null ? 0 : contentItem.xml.Length;
                    row["Metadata"] = contentItem.metadata;
                    row["Annotations"] = contentItem.annotations;
                    sdebug = "z9";

                    contentDataSet.Tables["Item"].Rows.Add(row);
                }
                sdebug = "z10";
                if (contentDataSet.Tables["ItemInstance"].Rows.Find(node.FullPath) == null)
                {
                    sdebug = "z11";
                    row = contentDataSet.Tables["ItemInstance"].NewRow();
                    row["ContentId"] = contentItem.contentId;
                    row["FullPath"] = node.FullPath;
                    contentDataSet.Tables["ItemInstance"].Rows.Add(row);
                    sdebug = "z12";
                }
                sdebug = "z13";
                foreach (string imageFilename in contentItem.ImageFilenames)
                {
                    sdebug = "z14";
                    row = contentDataSet.Tables["Picture"].NewRow();
                    row["ContentId"] = contentItem.contentId;
                    row["Filename"] = imageFilename;
                    sdebug = "z15";
                }


                sdebug = "z16";
                if (string.IsNullOrEmpty(contentItem.links) == false)
                {
                    sdebug = "z17";
                    XmlDocument linkDoc = new XmlDocument();
                    XmlNamespaceManager nsm = new XmlNamespaceManager(linkDoc.NameTable);
                    nsm.AddNamespace("k", "urn:mtpg-com:mtps/2004/1/key");
                    nsm.AddNamespace("mtps", "urn:msdn-com:public-content-syndication");
                    sdebug = "z18";

                    linkDoc.LoadXml(contentItem.links);
                    sdebug = "z19";

                    XmlNodeList nodes = linkDoc.SelectNodes("//mtps:link", nsm);
                    sdebug = "z20";

                    int z = 0;
                    foreach (XmlNode xmlNode in nodes)
                    {
                        z++;
                        sdebug = "z21_" + z.ToString();

                        XmlNode assetIdNode = xmlNode.SelectSingleNode("mtps:assetId", nsm);
                        XmlNode contentIdNode = xmlNode.SelectSingleNode("k:contentId", nsm);
                        sdebug = "z22_" + z.ToString();

                        if (assetIdNode == null || contentIdNode == null)
                            continue;

                        string assetId = assetIdNode.InnerText;
                        string contentId = contentIdNode.InnerText;
                        sdebug = "z23_" + z.ToString();

                        if (string.IsNullOrEmpty(assetId) == false)
                        {
                            // Remove "assetId:" from front
                            assetId = HttpUtility.UrlDecode(assetIdNode.InnerText.Remove(0, "assetId:".Length));
                            sdebug = "z24_" + z.ToString();

                            if (links.ContainsKey(assetId) == false)
                            {
                                links.Add(assetId, contentId);
                                sdebug = "z25_" + z.ToString();
                            }
                        }

                    }
                }

                sdebug = "z26";
                contentItem.Write(rawDir);
                sdebug = "z27";

                UpdateStatusText_ListTab(contentDataSet);
                //throw new Exception("Test Exception");
            }

            //
            // *** An attempt to catch some of these illusive errors
            //
            catch(Exception e)
            {
                exceptionCount++;
                UpdateStatusText_DebugTab();

                DebugOut("---------- Critical Exception ---------------- ");
                DebugOut("Exception time: ", DateTime.Now.ToString());

                String docContentId = "0";
                try
                {
                    docContentId = this.GetDocShortId(node);
                    DebugOut("mtpsNode.targetLocale: ", mtpsNode.targetLocale);
                    DebugOut("docContentId: ", docContentId);
                    DebugOut("mtpsNode.targetVersion: ", mtpsNode.targetVersion);
                }
                catch
                {
                }

                try
                {
                    DebugOut("Node.Text: ", node.Text);
                    DebugOut("Debug Point: ", sdebug);
                    DebugOut("e.Message: ", e.Message);
                    DebugOut("e.StackTrace: ", e.StackTrace);
                    DebugOut("e.Source: ", e.Source);
                    DebugOut("e.ToString: ", e.ToString());

                    String url;
                    if (rootContentItem.msdnSelected)
                        url = String.Format("http://msdn.microsoft.com/{0}/library/{1}({2}).aspx", mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion);
                    else
                        url = String.Format("http://technet.microsoft.com/{0}/library/{1}({2}).aspx", mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion);
                    DebugOut("URL: ", url);
                }
                catch
                {
                }

            }
            return true;
        }


        public void RemoveContent(TreeNode node, Content contentDataSet)
        {
            if (node.Tag != null)
            {
                MtpsNode mtpsNode = node.Tag as MtpsNode;

                DataRow row = contentDataSet.Tables["ItemInstance"].Rows.Find(node.FullPath);

                if (row != null)
                {
                    DataRow parentRow = row.GetParentRow("FK_Item_ItemInstance");
                    contentDataSet.Tables["ItemInstance"].Rows.Remove(row);
                    int count = parentRow.GetChildRows("FK_Item_ItemInstance").Length;

                    if (count == 0) // If there are no refs to this item, delete it and its files
                    {
                        foreach (string file in Directory.GetFiles(rawDir, 
                            parentRow["ContentId"].ToString() + "*"))
                        {
                            File.Delete(file);
                        }
                        contentDataSet.Tables["Item"].Rows.Remove(parentRow);
                    }
                    UpdateStatusText_ListTab(contentDataSet);
                }

            }
        }

        public void CreateChm(string chmFile, string title, string locale, Content contentDataSet)
        {
            Chm chm = new Chm(workingDir, title,
                chmFile, locale, tocControl.Nodes, contentDataSet, links);

            chm.Create();

            ExportProgressForm progressForm = new ExportProgressForm(chm, chm.expectedLines);
            progressForm.ShowDialog();

        }
        public void CreateMshc(string MshcFile, string locale, Content contentDataSet, string VendorName, string ProdName, string BookName,
            string RootTopicSuffix, string RootTopicParent, bool fTopicVersion, string TopicVersion)
        {
            Mshc mshc = new Mshc(workingDir, MshcFile, locale, tocControl.Nodes, contentDataSet, links, VendorName, ProdName, BookName,
                RootTopicSuffix, RootTopicParent, fTopicVersion, TopicVersion);

            //Mshc.Create();  //progress now calls this.. See Mshc.Compile()

            ExportProgressForm progressForm = new ExportProgressForm(mshc, mshc.expectedLines);
            progressForm.ShowDialog();

        }
        public void CreateHxs(string hxsFile, string title, string copyright, string locale, 
            Content contentDataSet)
        {
            HxS hxs = new HxS(workingDir, hxsFile,
                title, copyright, locale,
                tocControl.Nodes,
                contentDataSet,
                links);

            hxs.Create();

            ExportProgressForm hxsProgressForm = new ExportProgressForm(hxs, hxs.expectedLines);
            hxsProgressForm.ShowDialog();
        }


        private void DebugOut(String text)
        {
            if (_rtDebug != null)
               _rtDebug.WriteLine(text);
        }

        private void DebugOut(String text1, String text2)
        {
            if (_rtDebug != null)
                _rtDebug.WriteLine(text1, text2);
        }

        private void MessageBox_()
        {
            throw new NotImplementedException();
        }

        String debugTabText = "";
        String listTabText = "";

        public void UpdateStatusText_DebugTab()
        {
            if (_tabPage_Debug != null)
            {
                if (debugTabText == "")
                    debugTabText = _tabPage_Debug.Text;
                if (exceptionCount > 0)
                    _tabPage_Debug.Text = debugTabText + " (" + exceptionCount.ToString() + ")";
            }
        }

        public void UpdateStatusText_ListTab(Content contentDataSet)
        {
            if (_tabPage_List != null && contentDataSet != null)
            {
                if (listTabText == "")
                    listTabText = _tabPage_List.Text;
                if (contentDataSet.Item.Count == 0)
                    _tabPage_List.Text = listTabText;
                else
                    _tabPage_List.Text = listTabText + " (" + contentDataSet.Item.Count.ToString() + ")";
            }
        }


    }
}
