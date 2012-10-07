// Copyright (c) Microsoft Corporation.  All rights reserved.
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace PackageThis
{
    public partial class DownloadProgressForm : Form
    {
        private TreeNode node;
        private TreeNode startingNode;
        private bool decendingTree;
        private Content contentDataSet;
        private String dlgTitle;

        public struct DownloadData
        {
            public DateTime dlgStartTime;
            public DateTime dlgStopTime;
            public TimeSpan duration;
            public ulong countHtmlFiles;
            public ulong sizeHtmlFiles;
            public ulong countFiles;      //HTML + Image files
            public ulong sizeFiles;
        }
        private DownloadData dlData;
        public DownloadData DLData { get { return dlData; } }

        CultureInfo _currentCulture = CultureInfo.CurrentCulture;

        public DownloadProgressForm(TreeNode node, Content contentDataSet)
        {
            this.startingNode = node;
            this.node = node;
            this.contentDataSet = contentDataSet;
            this.decendingTree = true;
            dlData.dlgStartTime = DateTime.Now;

            InitializeComponent();

            //Scheduled Dialog used
            StopDate.Value = DateTime.Today;
            StopTime.Value = DateTime.Now;
            StopDate.MinDate = DateTime.Now.Date;
            if (ScheduleForm.sData.Enabled)
            {
                StopCbx.Checked = ScheduleForm.sData.xStop;
                if (StopCbx.Checked)
                {
                    StopDate.Value = ScheduleForm.sData.StopDate;
                    StopTime.Value = ScheduleForm.sData.StopTime;
                }
                StopAfterCbx.Checked = ScheduleForm.sData.xStopAfter;
                if (StopAfterCbx.Checked)
                {
                    StopAfterNum.Value = ScheduleForm.sData.StopAfter;
                }
            }

            //Off we go
            this.dlgTitle = this.Text;
            StopCountdownLabel.Text = "";
            timer1.Enabled = true;
        }


        public string convertToBinaryPrefixed(ulong value)
        {
            //string[] conversionTable = { "", "bytes", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB" };  //http://en.wikipedia.org/wiki/Kibibyte
            string[] conversionTable = { "", "bytes", "KB", "MB", "GB", "TB", "PB", "EB" };  //In Windows when we see KB we assume KiB (especially we programmers do)

            int i = 0;
            ulong previousValue = value;
            ulong sizeInB = value; 

            while (value != 0L)
            {
                previousValue = value;
                value >>= 10;
                i++;
            }

            return previousValue.ToString("N0", _currentCulture) + " " + conversionTable[i] + "  (" + sizeInB.ToString("N0", _currentCulture) + " bytes)";
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            String sText;

            if (node == null)
            {
                timer1.Enabled = false;
                this.Close();
                return;
            }

            node.Expand();                    //This triggers the node expand event and gets the child nodes
            if(node.Checked == false)
                node.Checked = true;          //This triggers the node check event and downloads the page

            if (node.Tag != null)
            {
                MtpsNode mtpsNode = node.Tag as MtpsNode;
                DownloadLabel.Text = mtpsNode.title;
                DownloadLabel.Update();
                DataRow row = contentDataSet.Tables["Item"].Rows.Find(mtpsNode.targetAssetId);

                int topicSize = 0;
                int picsSize = 0;
                int picsCount = 0;
                if (row != null)
                {
                    if (Int32.TryParse(row["Size"].ToString(), out topicSize))
                        dlData.sizeHtmlFiles += (ulong)topicSize;
                    if (Int32.TryParse(row["SizePictures"].ToString(), out picsSize))
                        dlData.sizeFiles = dlData.sizeFiles + (ulong)picsSize + (ulong)topicSize;  //size of topic + images
                    if (Int32.TryParse(row["Pictures"].ToString(), out picsCount))
                        dlData.countFiles += (ulong)picsCount + 1;  // +1 for topic
                }

                dlData.countHtmlFiles += 1;

                FilesLabel.Text = dlData.countHtmlFiles.ToString("N0", _currentCulture);
                TotalFilesLabel.Text = dlData.countFiles.ToString("N0", _currentCulture);
                SizeLabel.Text = convertToBinaryPrefixed(dlData.sizeHtmlFiles);
                TotalSizeLabel.Text = convertToBinaryPrefixed(dlData.sizeFiles);

                //warning .. Exceeded safe download limit
                if (dlData.countFiles > 10000 && toolStripStatusLabel1.Tag == null)
                {
                    toolStripStatusLabel1.Tag = 1;
                    toolStripStatusLabel1.Text = "Warning: Creating packages > 10,000 files is not recommended. Try making several smaller files.";
                    toolStripStatusLabel1.ForeColor = Color.White;
                    toolStripStatusLabel1.BackColor = Color.Red;
                    statusStrip1.BackColor = Color.Red;
                }
            }

            //Stop Scheduled?
            sText = "";
            if (StopCbx.Checked)
            {
                TimeSpan dateDiff = StopDate.Value.Subtract(DateTime.Today);
                TimeSpan timeDiff = StopTime.Value.Subtract(DateTime.Now);
                TimeSpan _dt = dateDiff.Add(timeDiff);

                if ((int)_dt.TotalDays > 0)
                    sText += ((int)_dt.TotalDays).ToString() + " days; ";
                if ((int)_dt.TotalSeconds > 0)
                    sText += _dt.Hours.ToString() + ":"
                        + _dt.Minutes.ToString() + ":"
                        + _dt.Seconds.ToString();

                if (_dt.TotalSeconds <= 0)
                {
                    timer1.Enabled = false;
                    this.Close();
                }
            }
            StopCountdownLabel.Text = sText;

            if (StopAfterCbx.Checked && dlData.countFiles >= StopAfterNum.Value)
            {
                timer1.Enabled = false;
                this.Close();
            }

            //Time lapse
            sText = "";
            TimeSpan timeLapse = DateTime.Now.Subtract(dlData.dlgStartTime);
            if ((int)timeLapse.TotalSeconds > 0)   //(@"dd\.hh\:mm\:ss")
            {
                if ((int)timeLapse.TotalDays > 0)
                    sText += timeLapse.ToString(@"dd\.");
                if (timeLapse.Hours > 0)
                    sText += timeLapse.ToString(@"hh\:");
                sText += timeLapse.ToString(@"mm\:ss");
            }
            this.Text = this.dlgTitle + " - " + sText;

            if (decendingTree == true && node.FirstNode != null)
            {
                node = node.FirstNode;
                decendingTree = true;
                
                return;
            }
            if (node.NextNode != null)
            {
                node = node.NextNode;
                decendingTree = true;
                
                return;
            }

            node = node.Parent;
            decendingTree = false;

            if (node == startingNode && decendingTree == false)
            {
                timer1.Enabled = false;
                this.Close();
            }

        }

        private void RequestCancelButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void DownloadProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            dlData.dlgStopTime = DateTime.Now;
            dlData.duration = dlData.dlgStopTime.Subtract(dlData.dlgStartTime);
        }



    }
}