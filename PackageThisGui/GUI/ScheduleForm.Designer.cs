namespace PackageThis
{
    partial class ScheduleForm
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
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.StartTime = new System.Windows.Forms.DateTimePicker();
            this.StopTime = new System.Windows.Forms.DateTimePicker();
            this.StopDate = new System.Windows.Forms.DateTimePicker();
            this.StopCbx = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.DownloadNodeLabel = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.StopAfterCbx = new System.Windows.Forms.CheckBox();
            this.StartCbx = new System.Windows.Forms.CheckBox();
            this.StopAfterNum = new System.Windows.Forms.NumericUpDown();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.backPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StopAfterNum)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.backPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(53, 84);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(216, 20);
            this.StartDate.TabIndex = 1;
            // 
            // StartTime
            // 
            this.StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTime.Location = new System.Drawing.Point(275, 84);
            this.StartTime.MinDate = new System.DateTime(2012, 10, 4, 0, 0, 0, 0);
            this.StartTime.Name = "StartTime";
            this.StartTime.ShowUpDown = true;
            this.StartTime.Size = new System.Drawing.Size(149, 20);
            this.StartTime.TabIndex = 2;
            // 
            // StopTime
            // 
            this.StopTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StopTime.Location = new System.Drawing.Point(275, 152);
            this.StopTime.MinDate = new System.DateTime(2012, 10, 4, 0, 0, 0, 0);
            this.StopTime.Name = "StopTime";
            this.StopTime.ShowUpDown = true;
            this.StopTime.Size = new System.Drawing.Size(149, 20);
            this.StopTime.TabIndex = 5;
            // 
            // StopDate
            // 
            this.StopDate.Location = new System.Drawing.Point(53, 152);
            this.StopDate.Name = "StopDate";
            this.StopDate.Size = new System.Drawing.Size(216, 20);
            this.StopDate.TabIndex = 4;
            // 
            // StopCbx
            // 
            this.StopCbx.AutoSize = true;
            this.StopCbx.Location = new System.Drawing.Point(27, 130);
            this.StopCbx.Name = "StopCbx";
            this.StopCbx.Size = new System.Drawing.Size(125, 17);
            this.StopCbx.TabIndex = 3;
            this.StopCbx.Text = "Stop Download Time";
            this.StopCbx.UseVisualStyleBackColor = true;
            this.StopCbx.CheckedChanged += new System.EventHandler(this.AnyCheckBox_Changed);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label1.Location = new System.Drawing.Point(22, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(95, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Download Branch:";
            // 
            // DownloadNodeLabel
            // 
            this.DownloadNodeLabel.AutoSize = true;
            this.DownloadNodeLabel.Location = new System.Drawing.Point(123, 19);
            this.DownloadNodeLabel.Name = "DownloadNodeLabel";
            this.DownloadNodeLabel.Size = new System.Drawing.Size(34, 13);
            this.DownloadNodeLabel.TabIndex = 10;
            this.DownloadNodeLabel.Text = "         ";
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.SystemColors.Control;
            this.StartBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.StartBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartBtn.Image = global::PackageThis.Properties.Resources.PackageThis_stopwatch1;
            this.StartBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartBtn.Location = new System.Drawing.Point(24, 6);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.StartBtn.Size = new System.Drawing.Size(169, 42);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Schedule";
            this.StartBtn.UseVisualStyleBackColor = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Control;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CancelBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelBtn.Location = new System.Drawing.Point(243, 18);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(86, 30);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // StopAfterCbx
            // 
            this.StopAfterCbx.AutoSize = true;
            this.StopAfterCbx.Location = new System.Drawing.Point(27, 192);
            this.StopAfterCbx.Name = "StopAfterCbx";
            this.StopAfterCbx.Size = new System.Drawing.Size(124, 17);
            this.StopAfterCbx.TabIndex = 6;
            this.StopAfterCbx.Text = "Stop Download After";
            this.StopAfterCbx.UseVisualStyleBackColor = true;
            this.StopAfterCbx.CheckedChanged += new System.EventHandler(this.AnyCheckBox_Changed);
            // 
            // StartCbx
            // 
            this.StartCbx.AutoSize = true;
            this.StartCbx.Location = new System.Drawing.Point(25, 61);
            this.StartCbx.Name = "StartCbx";
            this.StartCbx.Size = new System.Drawing.Size(125, 17);
            this.StartCbx.TabIndex = 0;
            this.StartCbx.Text = "Start Download Time";
            this.StartCbx.UseVisualStyleBackColor = true;
            this.StartCbx.CheckedChanged += new System.EventHandler(this.AnyCheckBox_Changed);
            // 
            // StopAfterNum
            // 
            this.StopAfterNum.Location = new System.Drawing.Point(156, 191);
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
            this.StopAfterNum.TabIndex = 7;
            this.StopAfterNum.ThousandsSeparator = true;
            this.StopAfterNum.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(243, 193);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(58, 13);
            this.downloadLabel.TabIndex = 8;
            this.downloadLabel.Text = "downloads";
            // 
            // HelpBtn
            // 
            this.HelpBtn.BackColor = System.Drawing.SystemColors.Control;
            this.HelpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HelpBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HelpBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpBtn.Location = new System.Drawing.Point(335, 18);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(86, 30);
            this.HelpBtn.TabIndex = 2;
            this.HelpBtn.Text = "Help";
            this.HelpBtn.UseVisualStyleBackColor = false;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.Green;
            this.InfoPanel.Controls.Add(this.StartTimeLabel);
            this.InfoPanel.Controls.Add(this.InfoLabel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(444, 28);
            this.InfoPanel.TabIndex = 1;
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.StartTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.StartTimeLabel.ForeColor = System.Drawing.Color.White;
            this.StartTimeLabel.Location = new System.Drawing.Point(172, 6);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(23, 15);
            this.StartTimeLabel.TabIndex = 1;
            this.StartTimeLabel.Text = "----";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.InfoLabel.ForeColor = System.Drawing.Color.White;
            this.InfoLabel.Location = new System.Drawing.Point(8, 6);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(158, 15);
            this.InfoLabel.TabIndex = 0;
            this.InfoLabel.Text = "Waiting for Scheduled Start:";
            // 
            // backPanel
            // 
            this.backPanel.Controls.Add(this.DownloadNodeLabel);
            this.backPanel.Controls.Add(this.StartDate);
            this.backPanel.Controls.Add(this.StartTime);
            this.backPanel.Controls.Add(this.downloadLabel);
            this.backPanel.Controls.Add(this.StopDate);
            this.backPanel.Controls.Add(this.StopAfterNum);
            this.backPanel.Controls.Add(this.StopTime);
            this.backPanel.Controls.Add(this.StartCbx);
            this.backPanel.Controls.Add(this.StopCbx);
            this.backPanel.Controls.Add(this.StopAfterCbx);
            this.backPanel.Controls.Add(this.Label1);
            this.backPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backPanel.Location = new System.Drawing.Point(0, 28);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(444, 295);
            this.backPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StartBtn);
            this.panel1.Controls.Add(this.CancelBtn);
            this.panel1.Controls.Add(this.HelpBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 64);
            this.panel1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ScheduleForm
            // 
            this.AcceptButton = this.StartBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(444, 323);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.InfoPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule Download";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScheduleForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.StopAfterNum)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label downloadLabel;
        public System.Windows.Forms.DateTimePicker StartDate;
        public System.Windows.Forms.DateTimePicker StartTime;
        public System.Windows.Forms.DateTimePicker StopTime;
        public System.Windows.Forms.DateTimePicker StopDate;
        public System.Windows.Forms.CheckBox StopCbx;
        public System.Windows.Forms.Label DownloadNodeLabel;
        public System.Windows.Forms.CheckBox StopAfterCbx;
        public System.Windows.Forms.CheckBox StartCbx;
        public System.Windows.Forms.NumericUpDown StopAfterNum;
        private System.Windows.Forms.Button HelpBtn;
        internal System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label StartTimeLabel;
        internal System.Windows.Forms.Timer timer1;
    }
}