namespace PackageThis
{
    partial class InstallMshcForm
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
            this.MshaFileTextBox = new System.Windows.Forms.TextBox();
            this.HV1VersionName = new System.Windows.Forms.TextBox();
            this.HV1ProdName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HV1LocaleName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.HV1rdo = new System.Windows.Forms.RadioButton();
            this.HV2rdo = new System.Windows.Forms.RadioButton();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HV2CatalogName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.HV2LocaleName = new System.Windows.Forms.TextBox();
            this.HV1ResetBtn = new System.Windows.Forms.Button();
            this.HV2ResetBtn = new System.Windows.Forms.Button();
            this.helpManagerlink = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MshaFileTextBox
            // 
            this.MshaFileTextBox.Location = new System.Drawing.Point(97, 44);
            this.MshaFileTextBox.Name = "MshaFileTextBox";
            this.MshaFileTextBox.Size = new System.Drawing.Size(364, 20);
            this.MshaFileTextBox.TabIndex = 2;
            // 
            // HV1VersionName
            // 
            this.HV1VersionName.Location = new System.Drawing.Point(267, 38);
            this.HV1VersionName.Name = "HV1VersionName";
            this.HV1VersionName.Size = new System.Drawing.Size(94, 20);
            this.HV1VersionName.TabIndex = 8;
            this.HV1VersionName.Text = "100";
            // 
            // HV1ProdName
            // 
            this.HV1ProdName.Location = new System.Drawing.Point(167, 38);
            this.HV1ProdName.Name = "HV1ProdName";
            this.HV1ProdName.Size = new System.Drawing.Size(94, 20);
            this.HV1ProdName.TabIndex = 6;
            this.HV1ProdName.Text = "vs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Product/Version/Locale:";
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(329, 301);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(80, 27);
            this.CancelBtn.TabIndex = 12;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(243, 301);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(80, 27);
            this.OKBtn.TabIndex = 11;
            this.OKBtn.Text = "Install";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(467, 42);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 3;
            this.BrowseBtn.Text = "&Browse...";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ".MSHA File:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(320, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = ".MSHA installation manifest (file is created with the .Mshc help file):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target help catalog:";
            // 
            // HV1LocaleName
            // 
            this.HV1LocaleName.Location = new System.Drawing.Point(367, 38);
            this.HV1LocaleName.Name = "HV1LocaleName";
            this.HV1LocaleName.Size = new System.Drawing.Size(94, 20);
            this.HV1LocaleName.TabIndex = 13;
            this.HV1LocaleName.Text = "en-US";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Note #1:  Use Help Manager to uninstall any old help before installing new help.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Msha files (*.msha)|*.msha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(368, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Important: Help Viewer 1.0 must use the file name \"HelpContentSetup.msha\"";
            // 
            // HV1rdo
            // 
            this.HV1rdo.AutoSize = true;
            this.HV1rdo.Location = new System.Drawing.Point(13, 7);
            this.HV1rdo.Name = "HV1rdo";
            this.HV1rdo.Size = new System.Drawing.Size(149, 17);
            this.HV1rdo.TabIndex = 17;
            this.HV1rdo.Text = "Help Viewer 1.x (VS 2010)";
            this.HV1rdo.UseVisualStyleBackColor = true;
            // 
            // HV2rdo
            // 
            this.HV2rdo.AutoSize = true;
            this.HV2rdo.Checked = true;
            this.HV2rdo.Location = new System.Drawing.Point(13, 73);
            this.HV2rdo.Name = "HV2rdo";
            this.HV2rdo.Size = new System.Drawing.Size(149, 17);
            this.HV2rdo.TabIndex = 18;
            this.HV2rdo.TabStop = true;
            this.HV2rdo.Text = "Help Viewer 2.x (VS 2012)";
            this.HV2rdo.UseVisualStyleBackColor = true;
            // 
            // HelpBtn
            // 
            this.HelpBtn.Location = new System.Drawing.Point(415, 301);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(80, 27);
            this.HelpBtn.TabIndex = 19;
            this.HelpBtn.Text = "Help";
            this.HelpBtn.UseVisualStyleBackColor = true;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HV2ResetBtn);
            this.panel1.Controls.Add(this.HV1ResetBtn);
            this.panel1.Controls.Add(this.HV2CatalogName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.HV2LocaleName);
            this.panel1.Controls.Add(this.HV1rdo);
            this.panel1.Controls.Add(this.HV2rdo);
            this.panel1.Controls.Add(this.HV1ProdName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.HV1VersionName);
            this.panel1.Controls.Add(this.HV1LocaleName);
            this.panel1.Location = new System.Drawing.Point(34, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 136);
            this.panel1.TabIndex = 20;
            // 
            // HV2CatalogName
            // 
            this.HV2CatalogName.Location = new System.Drawing.Point(167, 104);
            this.HV2CatalogName.Name = "HV2CatalogName";
            this.HV2CatalogName.Size = new System.Drawing.Size(194, 20);
            this.HV2CatalogName.TabIndex = 20;
            this.HV2CatalogName.Text = "VisualStudio11";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Catalog/Locale:";
            // 
            // HV2LocaleName
            // 
            this.HV2LocaleName.Location = new System.Drawing.Point(367, 104);
            this.HV2LocaleName.Name = "HV2LocaleName";
            this.HV2LocaleName.Size = new System.Drawing.Size(94, 20);
            this.HV2LocaleName.TabIndex = 22;
            this.HV2LocaleName.Text = "en-US";
            // 
            // HV1ResetBtn
            // 
            this.HV1ResetBtn.Location = new System.Drawing.Point(467, 38);
            this.HV1ResetBtn.Name = "HV1ResetBtn";
            this.HV1ResetBtn.Size = new System.Drawing.Size(56, 21);
            this.HV1ResetBtn.TabIndex = 23;
            this.HV1ResetBtn.Text = "Reset";
            this.HV1ResetBtn.UseVisualStyleBackColor = true;
            this.HV1ResetBtn.Click += new System.EventHandler(this.HV1ResetBtn_Click);
            // 
            // HV2ResetBtn
            // 
            this.HV2ResetBtn.Location = new System.Drawing.Point(467, 104);
            this.HV2ResetBtn.Name = "HV2ResetBtn";
            this.HV2ResetBtn.Size = new System.Drawing.Size(56, 21);
            this.HV2ResetBtn.TabIndex = 24;
            this.HV2ResetBtn.Text = "Reset";
            this.HV2ResetBtn.UseVisualStyleBackColor = true;
            this.HV2ResetBtn.Click += new System.EventHandler(this.HV2ResetBtn_Click);
            // 
            // helpManagerlink
            // 
            this.helpManagerlink.AutoSize = true;
            this.helpManagerlink.Location = new System.Drawing.Point(65, 308);
            this.helpManagerlink.Name = "helpManagerlink";
            this.helpManagerlink.Size = new System.Drawing.Size(103, 13);
            this.helpManagerlink.TabIndex = 21;
            this.helpManagerlink.TabStop = true;
            this.helpManagerlink.Text = "Open Help Manager";
            this.helpManagerlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helpManagerlink_LinkClicked);
            // 
            // InstallMshcForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(582, 341);
            this.Controls.Add(this.helpManagerlink);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MshaFileTextBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallMshcForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Install Mshc Help File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstallMshcForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox MshaFileTextBox;
        public System.Windows.Forms.TextBox HV1VersionName;
        public System.Windows.Forms.TextBox HV1ProdName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox HV1LocaleName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button HelpBtn;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RadioButton HV1rdo;
        public System.Windows.Forms.RadioButton HV2rdo;
        public System.Windows.Forms.TextBox HV2CatalogName;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox HV2LocaleName;
        private System.Windows.Forms.Button HV2ResetBtn;
        private System.Windows.Forms.Button HV1ResetBtn;
        private System.Windows.Forms.LinkLabel helpManagerlink;
    }
}