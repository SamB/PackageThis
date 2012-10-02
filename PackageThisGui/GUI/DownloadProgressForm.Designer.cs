// Copyright (c) Microsoft Corporation.  All rights reserved.
//
namespace PackageThis
{
    partial class DownloadProgressForm
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
            this.RequestCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FilesLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DownloadLabel = new System.Windows.Forms.Label();
            this.TotalFilesLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalSizeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequestCancelButton
            // 
            this.RequestCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RequestCancelButton.Location = new System.Drawing.Point(252, 87);
            this.RequestCancelButton.Name = "RequestCancelButton";
            this.RequestCancelButton.Size = new System.Drawing.Size(75, 23);
            this.RequestCancelButton.TabIndex = 0;
            this.RequestCancelButton.Text = "Cancel";
            this.RequestCancelButton.UseVisualStyleBackColor = true;
            this.RequestCancelButton.Click += new System.EventHandler(this.RequestCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Downloading:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Size:";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(122, 55);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(100, 13);
            this.SizeLabel.TabIndex = 5;
            this.SizeLabel.Text = "                               ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Topics Downloaded:";
            // 
            // FilesLabel
            // 
            this.FilesLabel.AutoSize = true;
            this.FilesLabel.Location = new System.Drawing.Point(122, 37);
            this.FilesLabel.Name = "FilesLabel";
            this.FilesLabel.Size = new System.Drawing.Size(58, 13);
            this.FilesLabel.TabIndex = 7;
            this.FilesLabel.Text = "                 ";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DownloadLabel
            // 
            this.DownloadLabel.AutoSize = true;
            this.DownloadLabel.Location = new System.Drawing.Point(89, 13);
            this.DownloadLabel.Name = "DownloadLabel";
            this.DownloadLabel.Size = new System.Drawing.Size(91, 13);
            this.DownloadLabel.TabIndex = 8;
            this.DownloadLabel.Text = "                            ";
            // 
            // TotalFilesLabel
            // 
            this.TotalFilesLabel.AutoSize = true;
            this.TotalFilesLabel.Location = new System.Drawing.Point(407, 37);
            this.TotalFilesLabel.Name = "TotalFilesLabel";
            this.TotalFilesLabel.Size = new System.Drawing.Size(82, 13);
            this.TotalFilesLabel.TabIndex = 10;
            this.TotalFilesLabel.Text = "                         ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Topics && Images:";
            // 
            // TotalSizeLabel
            // 
            this.TotalSizeLabel.AutoSize = true;
            this.TotalSizeLabel.Location = new System.Drawing.Point(407, 55);
            this.TotalSizeLabel.Name = "TotalSizeLabel";
            this.TotalSizeLabel.Size = new System.Drawing.Size(100, 13);
            this.TotalSizeLabel.TabIndex = 12;
            this.TotalSizeLabel.Text = "                               ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Size:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 122);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(586, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(452, 17);
            this.toolStripStatusLabel1.Text = "Note:  Press \'Cancel\' at any time. A download restart will continue where you lef" +
    "t off.";
            // 
            // DownloadProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 144);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TotalSizeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TotalFilesLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DownloadLabel);
            this.Controls.Add(this.FilesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RequestCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadProgressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downloading Content";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadProgressForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RequestCancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label TitleLabel;
        public System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FilesLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label DownloadLabel;
        private System.Windows.Forms.Label TotalFilesLabel;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label TotalSizeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}