// Copyright (c) Microsoft Corporation.  All rights reserved.
//
namespace PackageThis
{
    partial class ExportMshcForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.VendorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProdName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BookName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MshcFileTextBox = new System.Windows.Forms.TextBox();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RootTopicParent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RootTopicSuffix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TopicVersion = new System.Windows.Forms.TextBox();
            this.TopicVersionCbx = new System.Windows.Forms.CheckBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mshc File:";
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(461, 15);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(73, 22);
            this.BrowseBtn.TabIndex = 0;
            this.BrowseBtn.Text = "&Browse...";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Enabled = false;
            this.OKBtn.Location = new System.Drawing.Point(201, 282);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(87, 26);
            this.OKBtn.TabIndex = 11;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(294, 282);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(87, 26);
            this.CancelBtn.TabIndex = 12;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Mshc files (*.mshc)|*.mshc";
            // 
            // VendorName
            // 
            this.VendorName.Location = new System.Drawing.Point(91, 54);
            this.VendorName.Name = "VendorName";
            this.VendorName.Size = new System.Drawing.Size(364, 20);
            this.VendorName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vendor Name:";
            // 
            // ProdName
            // 
            this.ProdName.Location = new System.Drawing.Point(91, 80);
            this.ProdName.Name = "ProdName";
            this.ProdName.Size = new System.Drawing.Size(364, 20);
            this.ProdName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Product Name:";
            // 
            // BookName
            // 
            this.BookName.Location = new System.Drawing.Point(91, 107);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(364, 20);
            this.BookName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Book Name:";
            // 
            // MshcFileTextBox
            // 
            this.MshcFileTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.MshcFileTextBox.Location = new System.Drawing.Point(91, 15);
            this.MshcFileTextBox.Name = "MshcFileTextBox";
            this.MshcFileTextBox.ReadOnly = true;
            this.MshcFileTextBox.Size = new System.Drawing.Size(364, 20);
            this.MshcFileTextBox.TabIndex = 2;
            this.MshcFileTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // HelpBtn
            // 
            this.HelpBtn.Location = new System.Drawing.Point(387, 282);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(87, 26);
            this.HelpBtn.TabIndex = 13;
            this.HelpBtn.Text = "Help";
            this.HelpBtn.UseVisualStyleBackColor = true;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RootTopicParent);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RootTopicSuffix);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TopicVersion);
            this.groupBox1.Controls.Add(this.TopicVersionCbx);
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 117);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced";
            // 
            // RootTopicParent
            // 
            this.RootTopicParent.Location = new System.Drawing.Point(145, 51);
            this.RootTopicParent.Name = "RootTopicParent";
            this.RootTopicParent.Size = new System.Drawing.Size(298, 20);
            this.RootTopicParent.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Root Topic Parent:";
            // 
            // RootTopicSuffix
            // 
            this.RootTopicSuffix.Location = new System.Drawing.Point(145, 25);
            this.RootTopicSuffix.Name = "RootTopicSuffix";
            this.RootTopicSuffix.Size = new System.Drawing.Size(298, 20);
            this.RootTopicSuffix.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Root Topic Title Suffix:";
            // 
            // TopicVersion
            // 
            this.TopicVersion.Location = new System.Drawing.Point(145, 77);
            this.TopicVersion.Name = "TopicVersion";
            this.TopicVersion.Size = new System.Drawing.Size(298, 20);
            this.TopicVersion.TabIndex = 5;
            // 
            // TopicVersionCbx
            // 
            this.TopicVersionCbx.AutoSize = true;
            this.TopicVersionCbx.Checked = true;
            this.TopicVersionCbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopicVersionCbx.Location = new System.Drawing.Point(21, 79);
            this.TopicVersionCbx.Name = "TopicVersionCbx";
            this.TopicVersionCbx.Size = new System.Drawing.Size(107, 17);
            this.TopicVersionCbx.TabIndex = 4;
            this.TopicVersionCbx.Text = "Set TopicVersion";
            this.TopicVersionCbx.UseVisualStyleBackColor = true;
            this.TopicVersionCbx.CheckedChanged += new System.EventHandler(this.TopicVersionCbx_CheckedChanged_1);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(462, 74);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(72, 22);
            this.ResetBtn.TabIndex = 9;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // ExportMshcForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(550, 325);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.MshcFileTextBox);
            this.Controls.Add(this.BookName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ProdName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VendorName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportMshcForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export to Mshc File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportMshcForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        //public System.Windows.Forms.TextBox MshcFileTextBox;
        public System.Windows.Forms.TextBox MshcVendorNameBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.TextBox VendorName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox ProdName;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox BookName;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox MshcFileTextBox;
        private System.Windows.Forms.Button HelpBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox RootTopicParent;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox RootTopicSuffix;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TopicVersion;
        public System.Windows.Forms.CheckBox TopicVersionCbx;
        private System.Windows.Forms.Button ResetBtn;
    }
}