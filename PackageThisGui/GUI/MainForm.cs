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

namespace PackageThis
{
    public partial class MainForm : Form
    {
        static private AppController appController;
        static private string currentLocale = CultureInfo.CurrentCulture.Name.ToLower();
        static private string workingDir;
        static private string tempPath;
        static private string tempDir;

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

                SplashForm.Status("Loading controls...");
                populateLibraryMenu();

                appController = new AppController(rootContentItem.contentId, currentLocale, rootContentItem.version,
                    TOCTreeView, workingDir);

            }
            finally
            {
                SplashForm.Done();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Activate();  //The splash form will kick us to the back. This brings us forward again.
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
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                appController.ExpandNode(e.Node);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
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
            Cursor.Current = Cursors.WaitCursor;

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
                Cursor.Current = Cursors.Default;
            }

        }


        private void TOCTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            //string[] split = e.Node.FullPath.Split(new char[] {'\x0098'});

            
            if (e.Node.Checked == false)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (appController.WriteContent(e.Node, ContentDataSet) == false)
                        e.Cancel = true;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                appController.RemoveContent(e.Node, ContentDataSet);
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


        private void selectNodeAndChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadProgressForm dpf = new DownloadProgressForm(TOCTreeView.SelectedNode,
                ContentDataSet);

            dpf.ShowDialog();

        }

        private void deselectThisNodeAndAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
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
            catch (IOException ex)
            {
            }

        }

        private void CreateTempDir()
        {
            tempPath = Path.Combine(Path.GetTempPath(), "PackageThis");  // <-- If we are not going to cleanup properly then lets atleast group under this folder 
            tempDir = Path.GetRandomFileName();
            workingDir = Path.Combine(tempPath, tempDir) + "\\";
            Directory.CreateDirectory(workingDir);

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

        }

        private void exportToMshcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContentDataSet.Tables["Item"].Rows.Count == 0)
                return;

            ExportMshcForm frm = new ExportMshcForm();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            appController.CreateMshc(frm.MshcFileTextBox.Text,
                currentLocale, ContentDataSet, frm.VendorName.Text, frm.ProdName.Text, frm.BookName.Text);

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

        private void mnuInstallMshcHelpFile_Click(object sender, EventArgs e)
        {
            InstallMshcForm frm = new InstallMshcForm();
            frm.LocaleName.Text = currentLocale;

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            string HelpLibManagerExe = @"c:\program files\Microsoft Help Viewer\v1.0\HelpLibManager.exe";
            string arguments = String.Format(@"/product {0} /version {1} /locale {2}", frm.ProdName.Text, frm.VersionName.Text, frm.LocaleName.Text);

            // Install

            if (frm.MshaFileTextBox.Text.Length != 0)
                arguments = arguments + String.Format(@" /sourceMedia {0}", frm.MshaFileTextBox.Text);

            if (File.Exists(HelpLibManagerExe) == false)
            {
                MessageBox.Show("File not found: " +  HelpLibManagerExe);
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = HelpLibManagerExe;
            process.StartInfo.Arguments = arguments; 
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.Verb = "runas";  //run as administrator -- Required for installation
            process.Start();

        }

        //eg. Open associated web page http://msdn.microsoft.com/en-us/library/ms533050(v=vs.85).aspx
        private void gotoWebPage_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TOCTreeView.SelectedNode != null)
            {
                MtpsNode mtpsNode = TOCTreeView.SelectedNode.Tag as MtpsNode;
                String docContentId = appController.GetDocShortId(TOCTreeView.SelectedNode); 

                Process.Start(String.Format("http://msdn.microsoft.com/{0}/library/{1}({2}).aspx",
                    mtpsNode.targetLocale, docContentId, mtpsNode.targetVersion));
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


    }
}