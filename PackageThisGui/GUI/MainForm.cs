// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ContentServiceLibrary;
using System.Reflection;
using System.Diagnostics;
using PackageThis.MtpsFiles;
using MSHelpCompiler;
using Microsoft.Win32;
using MiscFuncs;

namespace PackageThis
{
    public partial class MainForm : Form
    {
        static private AppController appController;
        static private string currentLocale = CultureInfo.CurrentCulture.Name.ToLower();
        static private string workingDir;
        static private string cacheDir;
        static private string tempPath;
        static private string tempDir;

        private bool useWaitCursor = true;

        public MainForm()
        {
            SplashForm.Init();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = String.Format("Package This! - {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

                // Unicode Start of String, chosen to avoid collisions possible with default sep
                // when we serialize the path to a file.
                TOCTreeView.PathSeparator = "\x0098";

                CreateTempDir();

                rootContentItem.currentLibrary = Properties.Settings.Default.currentLibrary;

                //statusStrip1.Items.Add(workingDir);
                statusStrip1.Items.Add(rootContentItem.name);

                SplashForm.Status("Connecting to server...");  //First time we hit the server (at least in Australia) we get a 15 sec delay
                populateLocaleMenu();

                SplashForm.Status("Downloading content...");
                populateLibraryMenu();

                appController = new AppController(rootContentItem.contentId, currentLocale, rootContentItem.version,
                    TOCTreeView, workingDir);

                //Give AppController Access to the UI
                debugEdit.WordWrap = false;
                appController._rtDebug = new RichTextBoxFuncs(debugEdit);
                appController._rtDebug.WriteLine("Exceptions will appear here. Please report an errors reported to CodePlex.", Color.Chocolate);
                appController._rtDebug.WriteLine("");
                appController._tabControl = tabControl1;
                appController._tabPage_Debug = tabPage_Debug;
                appController._tabPage_List = tabPage_List;
            }
            finally
            {
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Activate();  //The splash form will kick us to the back. This brings us forward again.
            SplashForm.Done();
        }

        private void selectLocale_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selected = sender as ToolStripMenuItem;

        }

        private void populateLocaleMenu()
        {
            SortedDictionary<string, string> locales;
            ToolStripMenuItem menuItem;

            locales = Utility.GetLocales();   //First server call -- Slow -- Up to 15 seconds on an i7 notebook from Australia - But fast if you call the server again

            localeToolStripMenuItem.DropDownItems.Clear();

            foreach (string displayName in locales.Keys)
            {
                menuItem = new ToolStripMenuItem(displayName, null, localeToolStripMenuItem_Click);
                menuItem.Name = locales[displayName];
                localeToolStripMenuItem.DropDownItems.Add(menuItem);

                //if (currentLocale == locales[displayName])
                if (currentLocale.Substring(0, 3) == locales[displayName].Substring(0, 3))  //allows for en-au == en-us
                {
                    menuItem.Checked = true;
                    currentLocale = locales[displayName];  //record the locale that matches the MSDN locale pallet
                }
            }
        }

        private void populateLibraryMenu()
        {
            for(int i = 0; i < rootContentItem.libraries.Count; i++)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(rootContentItem.libraries[i], null,
                    libraryToolStripMenuItem_Click);

                menuItem.Name = rootContentItem.libraries[i];
                menuItem.Text = "&" + menuItem.Text;
                libraryToolStripMenuItem.DropDownItems.Insert(i, menuItem);

                if (rootContentItem.currentLibrary == i)
                    menuItem.Checked = true;
                else
                    menuItem.Checked = false;
            }
        }

        private void TOCTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (useWaitCursor) Cursor.Current = Cursors.WaitCursor;
            try
            {
                appController.ExpandNode(e.Node);
            }
            finally
            {
                if (useWaitCursor) Cursor.Current = Cursors.Default;
            }
        }

        private void localeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selected = sender as ToolStripMenuItem;

            if (selected.Checked == true)
                return;


            for(int i = 0; i < localeToolStripMenuItem.DropDownItems.Count; i++)
            {
                if ((localeToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked == true)
                {
                    (localeToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                }
            }

            selected.Checked = true;


            currentLocale = selected.Name;
            reloadLibrary();
        }

        private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selected = sender as ToolStripMenuItem;

            if (selected.Checked == true)
                return;

            for (int i = 0; i < libraryToolStripMenuItem.DropDownItems.Count; i++)
            {
                if ((libraryToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked == true)
                {
                    (libraryToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                }
            }

            selected.Checked = true;

            rootContentItem.currentLibrary = Properties.Settings.Default.currentLibrary = 
                rootContentItem.libraries.IndexOf(selected.Name);
            Properties.Settings.Default.Save();

            reloadLibrary();

        }

        private void reloadLibrary()
        {
            if (useWaitCursor) Cursor.Current = Cursors.WaitCursor;

            try
            {
                CleanUpTempDir();
                CreateTempDir();

                statusStrip1.Items.Clear();
                //statusStrip1.Items.Add(workingDir);
                statusStrip1.Items.Add(rootContentItem.name);

                TOCTreeView.BeginUpdate();
                TOCTreeView.Nodes.Clear();

                appController = new AppController(rootContentItem.contentId, currentLocale,
                    rootContentItem.version, TOCTreeView, workingDir);

                TOCTreeView.EndUpdate();

                if (ContentDataSet.Tables["ItemInstance"] != null)
                    ContentDataSet.Tables["ItemInstance"].Clear();

                if (ContentDataSet.Tables["Item"] != null)
                    ContentDataSet.Tables["Item"].Clear();

                if (ContentDataSet.Tables["Picture"] != null)
                    ContentDataSet.Tables["Picture"].Clear();
            }
            finally
            {
                if (useWaitCursor) Cursor.Current = Cursors.Default;
            }

        }


        private void TOCTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            //string[] split = e.Node.FullPath.Split(new char[] {'\x0098'});

            
            if (e.Node.Checked == false)
            {
                if (useWaitCursor) Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (appController.WriteContent(e.Node, ContentDataSet) == false)
                        e.Cancel = true;
                }
                finally
                {
                    if (useWaitCursor) Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                if (useWaitCursor) Cursor.Current = Cursors.WaitCursor;
                try
                {
                    appController.RemoveContent(e.Node, ContentDataSet);
                }
                finally
                {
                    if (useWaitCursor) Cursor.Current = Cursors.Default;
                }
            }
        }

        private void TOCTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TOCTreeView.SelectedNode = TOCTreeView.GetNodeAt(e.X, e.Y);
            } 

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                ContentDataSet.Tables["ItemInstance"].WriteXml(saveFileDialog1.FileName, XmlWriteMode.WriteSchema);
        }

        int _cDownloads = 0;

        private void toolStripMenuItem_DownloadAll_Click(object sender, EventArgs e)
        {
            if (TOCTreeView.SelectedNode == null)
                return;
            useWaitCursor = false;  //Don't need a wait corsor as we have a modal dialog
            try
            {
                DownloadProgressForm dpf = new DownloadProgressForm(TOCTreeView.SelectedNode,
                    ContentDataSet);

                dpf.ShowDialog();

                // display results in debug window
                DownloadProgressForm.DownloadData stats = dpf.DLData;
                if (stats.countFiles > 0)
                {
                    String dtFormat = "G";
                    _cDownloads++;
                    appController._rtDebug.WriteLine("Download Stats (" + _cDownloads.ToString() + ")", Color.BlueViolet, new Font("Verdana", 12, FontStyle.Underline));
                    if (stats.dlgStartTime.Date == stats.dlgStopTime.Date)
                        dtFormat = "T"; //time only
                    appController._rtDebug.WriteLine("Start Time:", stats.dlgStartTime.ToString(dtFormat));
                    appController._rtDebug.WriteLine("Stop Time:", stats.dlgStopTime.ToString(dtFormat));
                    appController._rtDebug.WriteLine("Duration:", stats.duration.ToString(@"dd\.hh\:mm\:ss"));
                    appController._rtDebug.WriteLine("Downloaded (HTML):", stats.countHtmlFiles.ToString("N0"));
                    appController._rtDebug.WriteLine("Downloaded (Images):", (stats.countFiles - stats.countHtmlFiles).ToString("N0"));
                    appController._rtDebug.WriteLine("Total Downloaded:", stats.countFiles.ToString("N0"));
                    appController._rtDebug.WriteLine("Size (HTML):", stats.sizeHtmlFiles.ToString("N0") + " bytes");
                    appController._rtDebug.WriteLine("Size (Images):", (stats.sizeFiles - stats.sizeHtmlFiles).ToString("N0") + " bytes");
                    appController._rtDebug.WriteLine("Total Size:", (stats.sizeFiles).ToString("N0") + " bytes");
                    appController._rtDebug.WriteLine("");
                }

            }
            finally
            {
                useWaitCursor = true;
            }
        }

        private void toolStripMenuItem_ScheduleDownload_Click(object sender, EventArgs e)
        {
            ScheduleForm.sData.Enabled = false;
            if (TOCTreeView.SelectedNode == null)
                return;
            useWaitCursor = false;  //Don't need a wait corsor as we have a modal dialog
            try
            {
                ScheduleForm sf = new ScheduleForm(TOCTreeView.SelectedNode,
                    ContentDataSet);

                sf.ShowDialog();
            }
            finally
            {
                useWaitCursor = true;
            }


            //Proceed with download
            if (ScheduleForm.sData.Enabled)
            {
                try
                {
                    toolStripMenuItem_DownloadAll_Click(sender, e);
                }
                catch
                {
                    ScheduleForm.sData.Enabled = false;
                }
            }

        }


        //Expand all sub nodes
        private void toolStripMenuItem_ExpandAll_Click(object sender, EventArgs e)
        {
            if (TOCTreeView.SelectedNode == null)
                return;
            useWaitCursor = false;  //Don't need a wait corsor as we have a modal dialog
            try
            {
                ExpandProgressForm epf = new ExpandProgressForm(TOCTreeView.SelectedNode);

                epf.ShowDialog();
            }
            finally
            {
                useWaitCursor = true;
            }
        }


        private void toolStripMenuItem_RemoveAll_Click(object sender, EventArgs e)
        {
            appController.UncheckNodes(TOCTreeView.SelectedNode);

        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanUpTempDir();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // TODO: Move this to AppController.

        private void CleanUpTempDir()
        {
            // Do some sanity checks on workingDir so we don't, due to a bug,
            // delete too much.

            if (workingDir.StartsWith(tempPath) != true)
                return;

            if (workingDir.Contains(tempDir) != true)
                return;

            try
            {
                Directory.Delete(workingDir, true);
            }
            catch //(IOException ex)
            {
            }

        }

        private void CreateTempDir()
        {
            tempPath = Path.Combine(Path.GetTempPath(), "PackageThis");  // <-- If we are not going to cleanup properly then lets atleast group under this folder 
            
            //Make the Temp dir 2012-09-12-231501 (12th Sept 2012, 23:15 & 01 second) in preparation for recovery code.
            DateTime now = DateTime.Now;
            tempDir = String.Format("{0}-{1}-{2}-{3}",
                now.Year.ToString("####"), now.Month.ToString("0#"), now.Day.ToString("0#"), now.ToString("HHmmss"));   // HH = 24 hour format
            //tempDir = Path.GetRandomFileName();

            workingDir = Path.Combine(tempPath, tempDir) + "\\";
            Directory.CreateDirectory(workingDir);

            cacheDir = Path.Combine(tempPath, "cache") + "\\";   // not currently used -- Data recovery will be difficult given the way the programn is written
            Directory.CreateDirectory(cacheDir);
        }

        private void exportToChmFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContentDataSet.Tables["Item"].Rows.Count == 0)
                return;

            //Test if HH Workshop installed
            string key = @"HKEY_CURRENT_USER\Software\Microsoft\HTML Help Workshop";
            string install = (string)Registry.GetValue(key, "InstallDir", null);
            string hhcExe =  Path.Combine(install, "hhc.exe");
            if (install == null || File.Exists(hhcExe) == false)
            {
                MessageBox.Show("Please install the HTML Help Workshop.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            


            ExportChmForm frm = new ExportChmForm();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            appController.CreateChm(frm.ChmFileTextBox.Text, frm.TitleTextBox.Text,
                currentLocale, ContentDataSet);

            //Show the output folder
            ShowFileinExplorer(frm.ChmFileTextBox.Text);
        }

        private void ShowFileinExplorer(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string argument = "/select, \"" + filePath + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
                catch
                {
                }
            }
        }

        private void exportToHxsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContentDataSet.Tables["Item"].Rows.Count == 0)
                return;

            // Test if Help SDK Install - Suck it and see
            try
            {
                HxComp hxsCompiler = new HxComp();
                hxsCompiler.Initialize();
                hxsCompiler = null;
            }
            catch
            {
                MessageBox.Show(@"Please install the VS 2005\2008 SDK, which includes the MS Help 2.x SDK and compiler.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GenerateHxsForm exportDialog = new GenerateHxsForm();

            if (exportDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            appController.CreateHxs(exportDialog.FileTextBox.Text,
                exportDialog.TitleTextBox.Text,
                exportDialog.CopyrightComboBox.Text,
                currentLocale,
                ContentDataSet);

            ShowFileinExplorer(exportDialog.FileTextBox.Text);
        }

        private void exportToMshcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContentDataSet.Tables["Item"].Rows.Count == 0)
                return;

            ExportMshcForm frm = new ExportMshcForm();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            appController.CreateMshc(frm.MshcFileTextBox.Text,
                currentLocale, ContentDataSet, frm.VendorName.Text, frm.ProdName.Text, frm.BookName.Text,
                frm.RootTopicSuffix.Text, frm.RootTopicParent.Text, frm.TopicVersionCbx.Checked, frm.TopicVersion.Text);

            ShowFileinExplorer(frm.MshcFileTextBox.Text);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox d = new AboutBox();
            d.ShowDialog(this);
        }

        public string AssemblyVersion { get; set; }



        private void toolStripMenuOnlineDocumentation_Click(object sender, EventArgs e)
        {
            Process.Start("http://packagethis.codeplex.com/documentation");
        }

        private void toolStripMenuTutorial_Click(object sender, EventArgs e)
        {
            Process.Start("http://packagethis.codeplex.com/wikipage?title=PackageThis%20Tutorial");
        }




        private void mnuInstallMshcHelpFile_Click(object sender, EventArgs e)
        {
            InstallMshcForm.defaultLocale = currentLocale;
            InstallMshcForm frm = new InstallMshcForm();

            if (frm.ShowDialog() != DialogResult.OK)
                return;
        }

        //eg. Open associated web page http://msdn.microsoft.com/en-us/library/ms533050(v=vs.85).aspx
        private void gotoWebPage_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TOCTreeView.SelectedNode != null)
            {
                MtpsNode mtpsNode = TOCTreeView.SelectedNode.Tag as MtpsNode;
                String docContentId = appController.GetDocShortId(TOCTreeView.SelectedNode);

                String url;
                if (rootContentItem.msdnSelected)
                    url = String.Format("http://msdn.microsoft.com/{0}/library/{1}({2}).aspx", mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion);
                else
                    url = String.Format("http://technet.microsoft.com/{0}/library/{1}({2}).aspx", mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion);
                Process.Start(url);
            }
        }

        //eg. Open associated mtps page of doc http://services.mtps.microsoft.com/serviceapi/content/ms533050/en-us;vs.85
        private void gotoMtpsPage_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TOCTreeView.SelectedNode != null)
            {
                MtpsNode mtpsNode = TOCTreeView.SelectedNode.Tag as MtpsNode;
                String docContentId = appController.GetDocShortId(TOCTreeView.SelectedNode);

                Process.Start(String.Format("http://services.mtps.microsoft.com/serviceapi/content/{1}/{0};{2}",
                    mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion));
            }
        }

        private void gotoTocMTPSPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TOCTreeView.SelectedNode != null)
            {
                MtpsNode mtpsNode = TOCTreeView.SelectedNode.Tag as MtpsNode;
                Process.Start(String.Format("http://services.mtps.microsoft.com/serviceapi/content/{1}/{0};{2}",
                   mtpsNode.navLocale, mtpsNode.targetContentId, mtpsNode.navVersion));
            }
        }


        private void menuStrip1_MenuActivate(object sender, EventArgs e)
        {
            Boolean hasTableItems = ContentDataSet.Tables["Item"].Rows.Count > 0;
            exportToChmFileToolStripMenuItem.Enabled = hasTableItems;
            exportToHxsFileToolStripMenuItem.Enabled = hasTableItems;
            exportToMshcFileToolStripMenuItem.Enabled = hasTableItems;
        }

        private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
        {
            exportToChmFileToolStripMenuItem.Enabled = true;
            exportToHxsFileToolStripMenuItem.Enabled = true;
            exportToMshcFileToolStripMenuItem.Enabled = true;
        }

        private void toolStripMenuOpenWorkDir_Click(object sender, EventArgs e)
        {
            Process.Start(workingDir);
        }

        //=============== Page Tabs =================

        TreeNode _lastTreeNodeSelected = null;

        private void ViewSelectedInOnlineTab()
        {
            if (_lastTreeNodeSelected != null)
            {
                MtpsNode mtpsNode = _lastTreeNodeSelected.Tag as MtpsNode;
                String docContentId = appController.GetDocShortId(_lastTreeNodeSelected);
                String url;
                if (rootContentItem.msdnSelected)
                    url = String.Format("http://msdn.microsoft.com/{0}/library/{1}({2}).aspx", mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion);
                else
                    url = String.Format("http://technet.microsoft.com/{0}/library/{1}({2}).aspx", mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion);
                webBrowser1.Navigate(url);
            }
        }

        private void TOCTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _lastTreeNodeSelected = TOCTreeView.SelectedNode;
            if (tabControl1.SelectedTab == tabPage_Online)
                ViewSelectedInOnlineTab();

            Boolean isSelected = _lastTreeNodeSelected != null;
            toolStripButton_RemoveAll.Enabled = isSelected;
            toolStripButton_ExpandAll.Enabled = isSelected;
            toolStripButton_Schedule.Enabled = isSelected;

            toolStripMenuItem_DownloadAll.Enabled = isSelected;
            toolStripMenuItem_RemoveAll.Enabled = isSelected;
            toolStripMenuItem_ExpandAll.Enabled = isSelected;
            toolStripMenuItem_ScheduleDownload.Enabled = isSelected;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage_Online)
                ViewSelectedInOnlineTab();
        }


        // Toolbar 

        private void toolStripButton_DownloadAll_ButtonClick(object sender, EventArgs e)
        {
            toolStripMenuItem_DownloadAll_Click(sender, e);
        }

        private void toolStripButton_RemoveAll_Click(object sender, EventArgs e)
        {
            if (TOCTreeView.SelectedNode != null)
                appController.UncheckNodes(TOCTreeView.SelectedNode);
        }

        private void toolStripButton_ExpandAll_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_ExpandAll_Click(sender, e);
        }

        private void toolStripButton_Schedule_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_ScheduleDownload_Click(sender, e);
        }

        //Button Hiver Tips

        private void BtnMouseEnter(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton item = sender as ToolStripButton;
                statusStrip1.Items.Clear();
                if (item.Tag is String)
                {
                    statusStrip1.BackColor = SystemColors.Window;
                    statusStrip1.Items.Add((String)item.Tag);
                }
            }
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                statusStrip1.Items.Clear();
                if (item.Tag is String)
                {
                    statusStrip1.BackColor = SystemColors.Window;
                    statusStrip1.Items.Add((String)item.Tag);
                }
            }
        }

        private void BtnMouseLeave(object sender, EventArgs e)
        {
            statusStrip1.BackColor = SystemColors.Control;
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(rootContentItem.name);  // MSDN or TechNet text
        }








    }
}