// Copyright (c) Microsoft Corporation.  All rights reserved.
//
namespace PackageThis
{
    partial class ExpandProgressForm
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
            this.CountLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RequestCancelButton
            // 
            this.RequestCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RequestCancelButton.Location = new System.Drawing.Point(68, 59);
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
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Child Node Count:";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoEllipsis = true;
            this.CountLabel.Location = new System.Drawing.Point(130, 18);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(70, 18);
            this.CountLabel.TabIndex = 4;
            this.CountLabel.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ExpandProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 94);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RequestCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpandProgressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expanding";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExpandProgressForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RequestCancelButton;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Timer timer1;
    }
}