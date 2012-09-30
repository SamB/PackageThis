// Copyright (c) Microsoft Corporation.  All rights reserved.
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PackageThis
{
    public partial class ExportMshcForm : Form
    {
        public ExportMshcForm()
        {
            InitializeComponent();

            //show last settings
            MshcFileTextBox.Text = Gui.GetString(Gui.VID_MshcFile, "");
            VendorName.Text = Gui.GetString(VendorName.Name, "PackageThis");
            RootTopicSuffix.Text = Gui.GetString(RootTopicSuffix.Name, " (PackageThis)");
            RootTopicParent.Text = Gui.GetString(RootTopicParent.Name, "-1");
            TopicVersionCbx.Checked = Gui.GetBool(TopicVersionCbx.Name, true);
            TopicVersion.Text = Gui.GetString(TopicVersion.Name, "999");
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            VendorName.Text = "PackageThis";
            UpdateFields();
            RootTopicSuffix.Text = " (PackageThis)";
            RootTopicParent.Text = "-1";
            TopicVersionCbx.Checked = true;
            TopicVersion.Text = "999";
        }

        public void UpdateFields()
        {
            String filename_NoExt = Path.GetFileNameWithoutExtension(MshcFileTextBox.Text);
            ProdName.Text = "PackageThis_" + filename_NoExt;   //these names must be unique for each package
            BookName.Text = "PackageThis_" + filename_NoExt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OKBtn.Enabled = (String.IsNullOrEmpty(MshcFileTextBox.Text) == false);
            UpdateFields();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            // RWC: open at location
            if (File.Exists(MshcFileTextBox.Text))
            {
                saveFileDialog1.FileName = Path.GetFileName(MshcFileTextBox.Text.Trim());
                saveFileDialog1.InitialDirectory = Path.GetDirectoryName(MshcFileTextBox.Text.Trim());
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MshcFileTextBox.Text = saveFileDialog1.FileName;
                this.ActiveControl = VendorName;
            }
        }

        private void TopicVersionCbx_CheckedChanged(object sender, EventArgs e)
        {
            TopicVersion.Enabled = TopicVersionCbx.Checked;
        }


        private void ExportMshcForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                MshcFileTextBox.Text = MshcFileTextBox.Text.Trim();
                VendorName.Text = VendorName.Text.Trim();
                ProdName.Text = ProdName.Text.Trim();
                BookName.Text = BookName.Text.Trim();
                RootTopicParent.Text = RootTopicParent.Text.Trim();
                if (RootTopicParent.Text == "")
                    RootTopicParent.Text = "-1";
                TopicVersion.Text = TopicVersion.Text.Trim();

                if (Directory.Exists(MshcFileTextBox.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("Can't create file \"" + Path.GetFileName(MshcFileTextBox.Text) + "\".\n\nA folder already exists with this name!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Vendor=Microsoft causes problems
                if (String.Compare(VendorName.Text, "Microsoft", true) == 0)
                {
                    DialogResult result;
                    result = MessageBox.Show("The Vendor name \"Microsoft\" is a special name and should not be used as it requires the package to be signed.\n\nContinue anyway?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    e.Cancel = (result == System.Windows.Forms.DialogResult.No);
                }

                //Save settings
                Gui.SetString(Gui.VID_MshcFile, MshcFileTextBox.Text);
                Gui.SetString(VendorName.Name, VendorName.Text);
                Gui.SetString(ProdName.Name, ProdName.Text);
                Gui.SetString(BookName.Name, BookName.Text);
                Gui.SetString(RootTopicSuffix.Name, RootTopicSuffix.Text);
                Gui.SetString(RootTopicParent.Name, RootTopicParent.Text);
                Gui.SetBool(TopicVersionCbx.Name, TopicVersionCbx.Checked);
                Gui.SetString(TopicVersion.Name, TopicVersion.Text);
            }
            
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://packagethis.codeplex.com/wikipage?title=MSHC%20Export%20Dialog");
        }

        private void TopicVersionCbx_CheckedChanged_1(object sender, EventArgs e)
        {
            TopicVersion.Enabled = TopicVersionCbx.Checked;
        }



    }
}