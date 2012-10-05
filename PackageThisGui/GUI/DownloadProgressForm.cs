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
        private ulong downloadSize;
        private ulong downloadSizeIncudingImages; 
        private int filesDownloaded;
        private ulong filesDownloadedIncudingImages; 
        private TreeNode node;
        private TreeNode startingNode;
        private bool decendingTree;
        private Content contentDataSet;
        private DateTime dlgStartTime;
        private String dlgTitle;

        CultureInfo _currentCulture = CultureInfo.CurrentCulture;

        public DownloadProgressForm(TreeNode node, Content contentDataSet)
        {
            this.startingNode = node;
            this.node = node;
            this.contentDataSet = contentDataSet;
            this.decendingTree = true;
            this.dlgStartTime = DateTime.Now;

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
                        downloadSize += (ulong)topicSize;
                    if (Int32.TryParse(row["SizePictures"].ToString(), out picsSize))
                        downloadSizeIncudingImages = downloadSizeIncudingImages + (ulong)picsSize + (ulong)topicSize;  //size of topic + images
                    if (Int32.TryParse(row["Pictures"].ToString(), out picsCount))
                        filesDownloadedIncudingImages += (ulong)picsCount + 1;  // +1 for topic
                }

                filesDownloaded += 1;

                FilesLabel.Text = filesDownloaded.ToString("N0", _currentCulture);
                TotalFilesLabel.Text = filesDownloadedIncudingImages.ToString("N0", _currentCulture);
                SizeLabel.Text = convertToBinaryPrefixed(downloadSize);
                TotalSizeLabel.Text = convertToBinaryPrefixed(downloadSizeIncudingImages);

                //warning .. Exceeded safe download limit
                if (filesDownloadedIncudingImages > 10000 && toolStripStatusLabel1.Tag == null)
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

            if (StopAfterCbx.Checked && filesDownloadedIncudingImages >= StopAfterNum.Value)
            {
                timer1.Enabled = false;
                this.Close();
            }

            if (node.Tag != null)
            {
                //Time lapse
                sText = "";
                TimeSpan timeLapse = DateTime.Now.Subtract(dlgStartTime);
                if ((int)timeLapse.TotalDays > 0)
                    sText += ((int)timeLapse.TotalDays).ToString() + " days; ";
                if ((int)timeLapse.TotalSeconds > 0)
                {
                    if (timeLapse.Hours > 0)
                        sText += timeLapse.Hours.ToString() + ":";
                    sText += timeLapse.Minutes.ToString() + ":"
                        + timeLapse.Seconds.ToString();
                }
                this.Text = this.dlgTitle + " - " + sText;
            }

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
        }



    }
}