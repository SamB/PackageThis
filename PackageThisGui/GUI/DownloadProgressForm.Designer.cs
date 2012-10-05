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
            this.label4 = new System.Windows.Forms.Label();
            this.StopDate = new System.Windows.Forms.DateTimePicker();
            this.StopAfterNum = new System.Windows.Forms.NumericUpDown();
            this.StopTime = new System.Windows.Forms.DateTimePicker();
            this.StopCbx = new System.Windows.Forms.CheckBox();
            this.StopAfterCbx = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.StopCountdownLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StopAfterNum)).BeginInit();
            this.SuspendLayout();
            // 
            // RequestCancelButton
            // 
            this.RequestCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RequestCancelButton.Location = new System.Drawing.Point(235, 258);
            this.RequestCancelButton.Name = "RequestCancelButton";
            this.RequestCancelButton.Size = new System.Drawing.Size(75, 23);
            this.RequestCancelButton.TabIndex = 20;
            this.RequestCancelButton.Text = "Cancel";
            this.RequestCancelButton.UseVisualStyleBackColor = true;
            this.RequestCancelButton.Click += new System.EventHandler(this.RequestCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Downloading:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total Size:";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(363, 98);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(100, 13);
            this.SizeLabel.TabIndex = 7;
            this.SizeLabel.Text = "                               ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Topics Only:";
            // 
            // FilesLabel
            // 
            this.FilesLabel.AutoSize = true;
            this.FilesLabel.Location = new System.Drawing.Point(363, 80);
            this.FilesLabel.Name = "FilesLabel";
            this.FilesLabel.Size = new System.Drawing.Size(58, 13);
            this.FilesLabel.TabIndex = 5;
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
            this.DownloadLabel.Size = new System.Drawing.Size(37, 13);
            this.DownloadLabel.TabIndex = 1;
            this.DownloadLabel.Text = "          ";
            // 
            // TotalFilesLabel
            // 
            this.TotalFilesLabel.AutoSize = true;
            this.TotalFilesLabel.Location = new System.Drawing.Point(127, 80);
            this.TotalFilesLabel.Name = "TotalFilesLabel";
            this.TotalFilesLabel.Size = new System.Drawing.Size(82, 13);
            this.TotalFilesLabel.TabIndex = 9;
            this.TotalFilesLabel.Text = "                         ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Topics && Images:";
            // 
            // TotalSizeLabel
            // 
            this.TotalSizeLabel.AutoSize = true;
            this.TotalSizeLabel.Location = new System.Drawing.Point(127, 98);
            this.TotalSizeLabel.Name = "TotalSizeLabel";
            this.TotalSizeLabel.Size = new System.Drawing.Size(100, 13);
            this.TotalSizeLabel.TabIndex = 11;
            this.TotalSizeLabel.Text = "                               ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total Size:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(579, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 21;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "downloads";
            // 
            // StopDate
            // 
            this.StopDate.Location = new System.Drawing.Point(62, 182);
            this.StopDate.Name = "StopDate";
            this.StopDate.Size = new System.Drawing.Size(216, 20);
            this.StopDate.TabIndex = 15;
            // 
            // StopAfterNum
            // 
            this.StopAfterNum.Location = new System.Drawing.Point(165, 215);
            this.StopAfterNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.StopAfterNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StopAfterNum.Name = "StopAfterNum";
            this.StopAfterNum.Size = new System.Drawing.Size(81, 20);
            this.StopAfterNum.TabIndex = 18;
            this.StopAfterNum.ThousandsSeparator = true;
            this.StopAfterNum.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // StopTime
            // 
            this.StopTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StopTime.Location = new System.Drawing.Point(284, 182);
            this.StopTime.MinDate = new System.DateTime(2012, 10, 4, 0, 0, 0, 0);
            this.StopTime.Name = "StopTime";
            this.StopTime.ShowUpDown = true;
            this.StopTime.Size = new System.Drawing.Size(149, 20);
            this.StopTime.TabIndex = 16;
            // 
            // StopCbx
            // 
            this.StopCbx.AutoSize = true;
            this.StopCbx.Location = new System.Drawing.Point(36, 160);
            this.StopCbx.Name = "StopCbx";
            this.StopCbx.Size = new System.Drawing.Size(125, 17);
            this.StopCbx.TabIndex = 14;
            this.StopCbx.Text = "Stop Download Time";
            this.StopCbx.UseVisualStyleBackColor = true;
            // 
            // StopAfterCbx
            // 
            this.StopAfterCbx.AutoSize = true;
            this.StopAfterCbx.Location = new System.Drawing.Point(36, 216);
            this.StopAfterCbx.Name = "StopAfterCbx";
            this.StopAfterCbx.Size = new System.Drawing.Size(124, 17);
            this.StopAfterCbx.TabIndex = 17;
            this.StopAfterCbx.Text = "Stop Download After";
            this.StopAfterCbx.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(12, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Downloads";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(15, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 1);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(15, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 1);
            this.panel2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(12, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Stop Download";
            // 
            // StopCountdownLabel
            // 
            this.StopCountdownLabel.AutoSize = true;
            this.StopCountdownLabel.Location = new System.Drawing.Point(449, 185);
            this.StopCountdownLabel.Name = "StopCountdownLabel";
            this.StopCountdownLabel.Size = new System.Drawing.Size(16, 13);
            this.StopCountdownLabel.TabIndex = 22;
            this.StopCountdownLabel.Text = "---";
            // 
            // DownloadProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.RequestCancelButton;
            this.ClientSize = new System.Drawing.Size(579, 320);
            this.Controls.Add(this.StopCountdownLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StopDate);
            this.Controls.Add(this.StopAfterNum);
            this.Controls.Add(this.StopTime);
            this.Controls.Add(this.StopCbx);
            this.Controls.Add(this.StopAfterCbx);
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
            ((System.ComponentModel.ISupportInitialize)(this.StopAfterNum)).EndInit();
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
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker StopDate;
        public System.Windows.Forms.NumericUpDown StopAfterNum;
        public System.Windows.Forms.DateTimePicker StopTime;
        public System.Windows.Forms.CheckBox StopCbx;
        public System.Windows.Forms.CheckBox StopAfterCbx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label StopCountdownLabel;
    }
}