// Copyright (c) Microsoft Corporation.  All rights reserved.
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PackageThis
{
    public partial class DownloadProgressForm : Form
    {
        private ulong downloadSize;
        private int filesDownloaded;
        private TreeNode node;
        private TreeNode startingNode;
        private bool decendingTree;
        private Content contentDataSet;

        public DownloadProgressForm(TreeNode node, Content contentDataSet)
        {
            this.startingNode = node;
            this.node = node;
            this.contentDataSet = contentDataSet;
            this.decendingTree = true;

            InitializeComponent();

            timer1.Enabled = true;
        }


        public string convertToBinaryPrefixed(ulong value)
        {
            //string[] conversionTable = { "", "bytes", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB" };  //http://en.wikipedia.org/wiki/Kibibyte
            string[] conversionTable = { "", "bytes", "KB", "MB", "GB", "TB", "PB", "EB" };  //In Windows when we see KB we assume KiB (especially we programmers do)

            int i = 0;
            ulong previousValue = value;

            while (value != 0L)
            {
                previousValue = value;
                value >>= 10;
                i++;
            }

            return previousValue.ToString() + " " + conversionTable[i];
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
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

                DataRow row = contentDataSet.Tables["Item"].Rows.Find(mtpsNode.targetAssetId);

                if (row != null)
                    downloadSize += (ulong)Int32.Parse(row["Size"].ToString());

                filesDownloaded += 1;

                FilesLabel.Text = filesDownloaded.ToString();
                SizeLabel.Text = convertToBinaryPrefixed(downloadSize);
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