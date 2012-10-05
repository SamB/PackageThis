// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace PackageThis
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToChmFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToHxsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToMshcFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpLibManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuOpenWorkDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDocumentation = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuTutorial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TOCTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DownloadAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ScheduleDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.gotoWebPage_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoMtpsPage_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTocMTPSPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_List = new System.Windows.Forms.TabPage();
            this.DocsGrid = new System.Windows.Forms.DataGridView();
            this.contentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picturesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizePictures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ContentDataSet = new PackageThis.Content();
            this.tabPage_Online = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage_Debug = new System.Windows.Forms.TabPage();
            this.debugEdit = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_RemoveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ExpandAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DownloadAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Schedule = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TreeViewMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContentDataSet)).BeginInit();
            this.tabPage_Online.SuspendLayout();
            this.tabPage_Debug.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.libraryToolStripMenuItem,
            this.localeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MenuActivate += new System.EventHandler(this.menuStrip1_MenuActivate);
            this.menuStrip1.MenuDeactivate += new System.EventHandler(this.menuStrip1_MenuDeactivate);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToChmFileToolStripMenuItem,
            this.exportToHxsFileToolStripMenuItem,
            this.toolStripSeparator7,
            this.exportToMshcFileToolStripMenuItem,
            this.mnuHelpLibManager,
            this.toolStripSeparator9,
            this.toolStripMenuOpenWorkDir,
            this.toolStripSeparator6,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Enabled = false;
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Visible = false;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem1.Text = "Load Selections...";
            this.toolStripMenuItem1.Visible = false;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(200, 6);
            this.toolStripSeparator.Visible = false;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.saveToolStripMenuItem.Text = "&Save Selections...";
            this.saveToolStripMenuItem.Visible = false;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Visible = false;
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Enabled = false;
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // exportToChmFileToolStripMenuItem
            // 
            this.exportToChmFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToChmFileToolStripMenuItem.Image")));
            this.exportToChmFileToolStripMenuItem.Name = "exportToChmFileToolStripMenuItem";
            this.exportToChmFileToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportToChmFileToolStripMenuItem.Text = "Export to &Chm File...";
            this.exportToChmFileToolStripMenuItem.ToolTipText = "HTML Help 1.x - General and application help";
            this.exportToChmFileToolStripMenuItem.Click += new System.EventHandler(this.exportToChmFileToolStripMenuItem_Click);
            // 
            // exportToHxsFileToolStripMenuItem
            // 
            this.exportToHxsFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToHxsFileToolStripMenuItem.Image")));
            this.exportToHxsFileToolStripMenuItem.Name = "exportToHxsFileToolStripMenuItem";
            this.exportToHxsFileToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportToHxsFileToolStripMenuItem.Text = "Export to &HxS File...";
            this.exportToHxsFileToolStripMenuItem.ToolTipText = "MS Help 2.x - Visual Studio 2002\\2003\\2005\\2008 help";
            this.exportToHxsFileToolStripMenuItem.Click += new System.EventHandler(this.exportToHxsFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(200, 6);
            // 
            // exportToMshcFileToolStripMenuItem
            // 
            this.exportToMshcFileToolStripMenuItem.Name = "exportToMshcFileToolStripMenuItem";
            this.exportToMshcFileToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportToMshcFileToolStripMenuItem.Text = "Export to &Mshc File...";
            this.exportToMshcFileToolStripMenuItem.ToolTipText = "MS Help Viewer 1.x - Visual Studio 2010 help";
            this.exportToMshcFileToolStripMenuItem.Click += new System.EventHandler(this.exportToMshcFileToolStripMenuItem_Click);
            // 
            // mnuHelpLibManager
            // 
            this.mnuHelpLibManager.Name = "mnuHelpLibManager";
            this.mnuHelpLibManager.Size = new System.Drawing.Size(203, 22);
            this.mnuHelpLibManager.Text = "Install Mshc Help File...";
            this.mnuHelpLibManager.Click += new System.EventHandler(this.mnuInstallMshcHelpFile_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(200, 6);
            // 
            // toolStripMenuOpenWorkDir
            // 
            this.toolStripMenuOpenWorkDir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuOpenWorkDir.Image")));
            this.toolStripMenuOpenWorkDir.Name = "toolStripMenuOpenWorkDir";
            this.toolStripMenuOpenWorkDir.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuOpenWorkDir.Text = "Open Work Directory";
            this.toolStripMenuOpenWorkDir.Click += new System.EventHandler(this.toolStripMenuOpenWorkDir_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(200, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Visible = false;
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Enabled = false;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            this.toolsToolStripMenuItem.Visible = false;
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Enabled = false;
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // libraryToolStripMenuItem
            // 
            this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
            this.libraryToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.libraryToolStripMenuItem.Text = "&Library";
            // 
            // localeToolStripMenuItem
            // 
            this.localeToolStripMenuItem.Name = "localeToolStripMenuItem";
            this.localeToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.localeToolStripMenuItem.Text = "L&ocale";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuDocumentation,
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripMenuTutorial,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMenuDocumentation
            // 
            this.toolStripMenuDocumentation.Name = "toolStripMenuDocumentation";
            this.toolStripMenuDocumentation.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuDocumentation.Text = "&Online Documentation";
            this.toolStripMenuDocumentation.Click += new System.EventHandler(this.toolStripMenuOnlineDocumentation_Click);
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Enabled = false;
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            this.contentsToolStripMenuItem.Visible = false;
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Enabled = false;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            this.indexToolStripMenuItem.Visible = false;
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Enabled = false;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            this.searchToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuTutorial
            // 
            this.toolStripMenuTutorial.Name = "toolStripMenuTutorial";
            this.toolStripMenuTutorial.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuTutorial.Text = "Tutorial";
            this.toolStripMenuTutorial.Click += new System.EventHandler(this.toolStripMenuTutorial_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(192, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1035, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TOCTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1035, 545);
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.TabIndex = 2;
            // 
            // TOCTreeView
            // 
            this.TOCTreeView.BackColor = System.Drawing.Color.White;
            this.TOCTreeView.CheckBoxes = true;
            this.TOCTreeView.ContextMenuStrip = this.TreeViewMenu;
            this.TOCTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TOCTreeView.FullRowSelect = true;
            this.TOCTreeView.HideSelection = false;
            this.TOCTreeView.Location = new System.Drawing.Point(0, 0);
            this.TOCTreeView.Name = "TOCTreeView";
            this.TOCTreeView.Size = new System.Drawing.Size(343, 545);
            this.TOCTreeView.TabIndex = 0;
            this.toolTip1.SetToolTip(this.TOCTreeView, "Nodes in red are not available in the content service.");
            this.TOCTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.TOCTreeView_BeforeCheck);
            this.TOCTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TOCTreeView_BeforeExpand);
            this.TOCTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TOCTreeView_AfterSelect);
            this.TOCTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TOCTreeView_MouseDown);
            // 
            // TreeViewMenu
            // 
            this.TreeViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DownloadAll,
            this.toolStripMenuItem_RemoveAll,
            this.toolStripSeparator8,
            this.toolStripMenuItem_ExpandAll,
            this.toolStripMenuItem_ScheduleDownload,
            this.toolStripSeparator10,
            this.gotoWebPage_toolStripMenuItem,
            this.gotoMtpsPage_toolStripMenuItem,
            this.showTocMTPSPageToolStripMenuItem});
            this.TreeViewMenu.Name = "TreeViewMenu";
            this.TreeViewMenu.Size = new System.Drawing.Size(187, 170);
            // 
            // toolStripMenuItem_DownloadAll
            // 
            this.toolStripMenuItem_DownloadAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_DownloadAll.Image")));
            this.toolStripMenuItem_DownloadAll.Name = "toolStripMenuItem_DownloadAll";
            this.toolStripMenuItem_DownloadAll.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_DownloadAll.Tag = "Download (&& check) selected item and all sub items";
            this.toolStripMenuItem_DownloadAll.Text = "Download All";
            this.toolStripMenuItem_DownloadAll.Click += new System.EventHandler(this.toolStripMenuItem_DownloadAll_Click);
            this.toolStripMenuItem_DownloadAll.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripMenuItem_DownloadAll.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // toolStripMenuItem_RemoveAll
            // 
            this.toolStripMenuItem_RemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_RemoveAll.Image")));
            this.toolStripMenuItem_RemoveAll.Name = "toolStripMenuItem_RemoveAll";
            this.toolStripMenuItem_RemoveAll.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_RemoveAll.Tag = "Remove downloads (&& uncheck) from selected item and all sub items";
            this.toolStripMenuItem_RemoveAll.Text = "Remove All";
            this.toolStripMenuItem_RemoveAll.Click += new System.EventHandler(this.toolStripMenuItem_RemoveAll_Click);
            this.toolStripMenuItem_RemoveAll.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripMenuItem_RemoveAll.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(183, 6);
            // 
            // toolStripMenuItem_ExpandAll
            // 
            this.toolStripMenuItem_ExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_ExpandAll.Image")));
            this.toolStripMenuItem_ExpandAll.Name = "toolStripMenuItem_ExpandAll";
            this.toolStripMenuItem_ExpandAll.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_ExpandAll.Tag = "Expand selected TOC branch (with no downloads)";
            this.toolStripMenuItem_ExpandAll.Text = "Expand All";
            this.toolStripMenuItem_ExpandAll.Click += new System.EventHandler(this.toolStripMenuItem_ExpandAll_Click);
            this.toolStripMenuItem_ExpandAll.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripMenuItem_ExpandAll.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // toolStripMenuItem_ScheduleDownload
            // 
            this.toolStripMenuItem_ScheduleDownload.Image = global::PackageThis.Properties.Resources.PackageThis_stopwatch1;
            this.toolStripMenuItem_ScheduleDownload.Name = "toolStripMenuItem_ScheduleDownload";
            this.toolStripMenuItem_ScheduleDownload.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem_ScheduleDownload.Tag = "Schedule a download";
            this.toolStripMenuItem_ScheduleDownload.Text = "Schedule";
            this.toolStripMenuItem_ScheduleDownload.Click += new System.EventHandler(this.toolStripMenuItem_ScheduleDownload_Click);
            this.toolStripMenuItem_ScheduleDownload.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripMenuItem_ScheduleDownload.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(183, 6);
            // 
            // gotoWebPage_toolStripMenuItem
            // 
            this.gotoWebPage_toolStripMenuItem.Name = "gotoWebPage_toolStripMenuItem";
            this.gotoWebPage_toolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.gotoWebPage_toolStripMenuItem.Tag = "Show associated web page in browser";
            this.gotoWebPage_toolStripMenuItem.Text = "View Web Page";
            this.gotoWebPage_toolStripMenuItem.Click += new System.EventHandler(this.gotoWebPage_toolStripMenuItem_Click);
            this.gotoWebPage_toolStripMenuItem.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.gotoWebPage_toolStripMenuItem.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // gotoMtpsPage_toolStripMenuItem
            // 
            this.gotoMtpsPage_toolStripMenuItem.Name = "gotoMtpsPage_toolStripMenuItem";
            this.gotoMtpsPage_toolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.gotoMtpsPage_toolStripMenuItem.Tag = "Show MTPS (MSDN/TechNet Publishing System) document page in browser";
            this.gotoMtpsPage_toolStripMenuItem.Text = "View Doc MTPS Page";
            this.gotoMtpsPage_toolStripMenuItem.Click += new System.EventHandler(this.gotoMtpsPage_toolStripMenuItem_Click);
            this.gotoMtpsPage_toolStripMenuItem.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.gotoMtpsPage_toolStripMenuItem.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // showTocMTPSPageToolStripMenuItem
            // 
            this.showTocMTPSPageToolStripMenuItem.Name = "showTocMTPSPageToolStripMenuItem";
            this.showTocMTPSPageToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showTocMTPSPageToolStripMenuItem.Tag = "Show MTPS (MSDN/TechNet Publishing System) toc item page in browser";
            this.showTocMTPSPageToolStripMenuItem.Text = "View Toc MTPS Page";
            this.showTocMTPSPageToolStripMenuItem.Click += new System.EventHandler(this.gotoTocMTPSPageToolStripMenuItem_Click);
            this.showTocMTPSPageToolStripMenuItem.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.showTocMTPSPageToolStripMenuItem.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_List);
            this.tabControl1.Controls.Add(this.tabPage_Online);
            this.tabControl1.Controls.Add(this.tabPage_Debug);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(122, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(688, 545);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_List
            // 
            this.tabPage_List.Controls.Add(this.DocsGrid);
            this.tabPage_List.Location = new System.Drawing.Point(4, 22);
            this.tabPage_List.Name = "tabPage_List";
            this.tabPage_List.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_List.Size = new System.Drawing.Size(680, 519);
            this.tabPage_List.TabIndex = 0;
            this.tabPage_List.Text = "Topics";
            this.toolTip1.SetToolTip(this.tabPage_List, "List of topics downloaded and ready to package");
            this.tabPage_List.UseVisualStyleBackColor = true;
            // 
            // DocsGrid
            // 
            this.DocsGrid.AllowUserToAddRows = false;
            this.DocsGrid.AllowUserToDeleteRows = false;
            this.DocsGrid.AllowUserToOrderColumns = true;
            this.DocsGrid.AllowUserToResizeRows = false;
            this.DocsGrid.AutoGenerateColumns = false;
            this.DocsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DocsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DocsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DocsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contentIdDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.versionIdDataGridViewTextBoxColumn,
            this.assetIdDataGridViewTextBoxColumn,
            this.picturesDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.SizePictures});
            this.DocsGrid.DataSource = this.itemsBindingSource;
            this.DocsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocsGrid.Location = new System.Drawing.Point(3, 3);
            this.DocsGrid.Name = "DocsGrid";
            this.DocsGrid.ReadOnly = true;
            this.DocsGrid.RowHeadersVisible = false;
            this.DocsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DocsGrid.Size = new System.Drawing.Size(674, 513);
            this.DocsGrid.TabIndex = 0;
            // 
            // contentIdDataGridViewTextBoxColumn
            // 
            this.contentIdDataGridViewTextBoxColumn.DataPropertyName = "ContentId";
            this.contentIdDataGridViewTextBoxColumn.HeaderText = "ContentId";
            this.contentIdDataGridViewTextBoxColumn.Name = "contentIdDataGridViewTextBoxColumn";
            this.contentIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.contentIdDataGridViewTextBoxColumn.Width = 78;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 52;
            // 
            // versionIdDataGridViewTextBoxColumn
            // 
            this.versionIdDataGridViewTextBoxColumn.DataPropertyName = "VersionId";
            this.versionIdDataGridViewTextBoxColumn.HeaderText = "VersionId";
            this.versionIdDataGridViewTextBoxColumn.Name = "versionIdDataGridViewTextBoxColumn";
            this.versionIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionIdDataGridViewTextBoxColumn.Width = 76;
            // 
            // assetIdDataGridViewTextBoxColumn
            // 
            this.assetIdDataGridViewTextBoxColumn.DataPropertyName = "AssetId";
            this.assetIdDataGridViewTextBoxColumn.HeaderText = "AssetId";
            this.assetIdDataGridViewTextBoxColumn.Name = "assetIdDataGridViewTextBoxColumn";
            this.assetIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.assetIdDataGridViewTextBoxColumn.Width = 67;
            // 
            // picturesDataGridViewTextBoxColumn
            // 
            this.picturesDataGridViewTextBoxColumn.DataPropertyName = "Pictures";
            this.picturesDataGridViewTextBoxColumn.HeaderText = "Pictures";
            this.picturesDataGridViewTextBoxColumn.Name = "picturesDataGridViewTextBoxColumn";
            this.picturesDataGridViewTextBoxColumn.ReadOnly = true;
            this.picturesDataGridViewTextBoxColumn.Width = 70;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeDataGridViewTextBoxColumn.Width = 52;
            // 
            // SizePictures
            // 
            this.SizePictures.DataPropertyName = "SizePictures";
            this.SizePictures.HeaderText = "SizePictures";
            this.SizePictures.Name = "SizePictures";
            this.SizePictures.ReadOnly = true;
            this.SizePictures.Width = 90;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Item";
            this.itemsBindingSource.DataSource = this.ContentDataSet;
            // 
            // ContentDataSet
            // 
            this.ContentDataSet.DataSetName = "Content";
            this.ContentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage_Online
            // 
            this.tabPage_Online.Controls.Add(this.webBrowser1);
            this.tabPage_Online.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Online.Name = "tabPage_Online";
            this.tabPage_Online.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Online.Size = new System.Drawing.Size(680, 519);
            this.tabPage_Online.TabIndex = 1;
            this.tabPage_Online.Text = "Online";
            this.tabPage_Online.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(674, 513);
            this.webBrowser1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.webBrowser1, "Online page of selected node");
            // 
            // tabPage_Debug
            // 
            this.tabPage_Debug.Controls.Add(this.debugEdit);
            this.tabPage_Debug.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Debug.Name = "tabPage_Debug";
            this.tabPage_Debug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Debug.Size = new System.Drawing.Size(680, 519);
            this.tabPage_Debug.TabIndex = 2;
            this.tabPage_Debug.Text = "Debug";
            this.tabPage_Debug.UseVisualStyleBackColor = true;
            // 
            // debugEdit
            // 
            this.debugEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debugEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugEdit.Location = new System.Drawing.Point(3, 3);
            this.debugEdit.Name = "debugEdit";
            this.debugEdit.Size = new System.Drawing.Size(674, 513);
            this.debugEdit.TabIndex = 0;
            this.debugEdit.Text = "";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 25000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML files|*.xml";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_DownloadAll,
            this.toolStripButton_RemoveAll,
            this.toolStripSeparator11,
            this.toolStripButton_ExpandAll,
            this.toolStripButton_Schedule});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 1, 1, 1);
            this.toolStrip1.Size = new System.Drawing.Size(1035, 33);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_RemoveAll
            // 
            this.toolStripButton_RemoveAll.AutoToolTip = false;
            this.toolStripButton_RemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_RemoveAll.Image")));
            this.toolStripButton_RemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemoveAll.Name = "toolStripButton_RemoveAll";
            this.toolStripButton_RemoveAll.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripButton_RemoveAll.Size = new System.Drawing.Size(95, 28);
            this.toolStripButton_RemoveAll.Tag = "Remove downloads (&& uncheck) from selected item and all sub items";
            this.toolStripButton_RemoveAll.Text = "Remove All";
            this.toolStripButton_RemoveAll.Click += new System.EventHandler(this.toolStripButton_RemoveAll_Click);
            this.toolStripButton_RemoveAll.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripButton_RemoveAll.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton_ExpandAll
            // 
            this.toolStripButton_ExpandAll.AutoToolTip = false;
            this.toolStripButton_ExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ExpandAll.Image")));
            this.toolStripButton_ExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ExpandAll.Name = "toolStripButton_ExpandAll";
            this.toolStripButton_ExpandAll.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripButton_ExpandAll.Size = new System.Drawing.Size(90, 28);
            this.toolStripButton_ExpandAll.Tag = "Expand selected TOC branch (with no downloads)";
            this.toolStripButton_ExpandAll.Text = "Expand All";
            this.toolStripButton_ExpandAll.Click += new System.EventHandler(this.toolStripButton_ExpandAll_Click);
            this.toolStripButton_ExpandAll.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripButton_ExpandAll.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // toolStripButton_DownloadAll
            // 
            this.toolStripButton_DownloadAll.AutoToolTip = false;
            this.toolStripButton_DownloadAll.Image = global::PackageThis.Properties.Resources.PackageThis_bw_dl;
            this.toolStripButton_DownloadAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DownloadAll.Name = "toolStripButton_DownloadAll";
            this.toolStripButton_DownloadAll.Size = new System.Drawing.Size(98, 28);
            this.toolStripButton_DownloadAll.Tag = "Download (&& check) selected item and all sub items";
            this.toolStripButton_DownloadAll.Text = "Download All";
            this.toolStripButton_DownloadAll.Click += new System.EventHandler(this.toolStripButton_DownloadAll_ButtonClick);
            this.toolStripButton_DownloadAll.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripButton_DownloadAll.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // toolStripButton_Schedule
            // 
            this.toolStripButton_Schedule.AutoToolTip = false;
            this.toolStripButton_Schedule.Image = global::PackageThis.Properties.Resources.PackageThis_stopwatch1;
            this.toolStripButton_Schedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Schedule.Name = "toolStripButton_Schedule";
            this.toolStripButton_Schedule.Size = new System.Drawing.Size(75, 28);
            this.toolStripButton_Schedule.Tag = "Schedule a download";
            this.toolStripButton_Schedule.Text = "Schedule";
            this.toolStripButton_Schedule.Click += new System.EventHandler(this.toolStripButton_Schedule_Click);
            this.toolStripButton_Schedule.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
            this.toolStripButton_Schedule.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1035, 624);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Package This!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TreeViewMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_List.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DocsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContentDataSet)).EndInit();
            this.tabPage_Online.ResumeLayout(false);
            this.tabPage_Debug.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TOCTreeView;
        private System.Windows.Forms.DataGridView DocsGrid;
        private System.Windows.Forms.ToolStripMenuItem localeToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn picturesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private Content ContentDataSet;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem exportToHxsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ContextMenuStrip TreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DownloadAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RemoveAll;
        private System.Windows.Forms.ToolStripMenuItem exportToChmFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToMshcFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDocumentation;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpLibManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem gotoWebPage_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoMtpsPage_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTocMTPSPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOpenWorkDir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_List;
        private System.Windows.Forms.TabPage tabPage_Online;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ExpandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.TabPage tabPage_Debug;
        public System.Windows.Forms.RichTextBox debugEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuTutorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizePictures;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemoveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton toolStripButton_ExpandAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ScheduleDownload;
        private System.Windows.Forms.ToolStripButton toolStripButton_DownloadAll;
        private System.Windows.Forms.ToolStripButton toolStripButton_Schedule;
        
    }
}

