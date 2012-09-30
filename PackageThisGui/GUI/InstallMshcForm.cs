using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MiscFuncs;

namespace PackageThis
{
    public partial class InstallMshcForm : Form
    {
        static public string defaultLocale = "en-us";    //caller can set this before creation

        public InstallMshcForm()
        {
            InitializeComponent();

            //show last settings -- The .msha file lives in the same folder as the .mshc file

            String mshcFileName = Gui.GetString(Gui.VID_MshcFile, "");  //The file entered in the export dialog
            if ((object)mshcFileName != null && mshcFileName.Length != 0)
            {
                MshaFileTextBox.Text = Path.Combine(Path.GetDirectoryName(mshcFileName), Path.GetFileNameWithoutExtension(mshcFileName) + ".msha");
                //MshaFileTextBox.Text = Path.GetDirectoryName(mshcFileName) + @"\HelpContentSetup.msha";   //This must be used for VS 10 RTM
            }
            else
            {
                MshaFileTextBox.Text = Gui.GetString(MshaFileTextBox.Name, "");  //get last used
            }

            // initial settings 

            HV1ProdName.Text = Gui.GetString(HV1ProdName.Name, "vs");
            HV1VersionName.Text = Gui.GetString(HV1VersionName.Name, "100");
            HV1LocaleName.Text = Gui.GetString(HV1LocaleName.Name, defaultLocale);

            HV2CatalogName.Text = Gui.GetString(HV2CatalogName.Name, "VisualStudio11");
            HV2LocaleName.Text = Gui.GetString(HV2LocaleName.Name, defaultLocale);

            HV2rdo.Checked = Gui.GetBool(HV2rdo.Name, true);
            HV1rdo.Checked = !HV2rdo.Checked;
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MshaFileTextBox.Text = openFileDialog1.FileName;
                this.ActiveControl = MshaFileTextBox;
            }
        }

        private void TrimWhiteSpace()
        {
            //Trim Whitespace
            MshaFileTextBox.Text = MshaFileTextBox.Text.Trim();

            HV1ProdName.Text = HV1ProdName.Text.Trim();
            HV1VersionName.Text = HV1VersionName.Text.Trim();
            HV1LocaleName.Text = HV1LocaleName.Text.Trim();

            HV2CatalogName.Text = HV2CatalogName.Text.Trim();
            HV2LocaleName.Text = HV2LocaleName.Text.Trim();
        }


        private void InstallMshcForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                TrimWhiteSpace();

                if (!File.Exists(MshaFileTextBox.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show(".MSHA installation manifest file not found \"" + MshaFileTextBox.Text + "\"",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Save settings
                Gui.SetString(MshaFileTextBox.Name, MshaFileTextBox.Text);

                Gui.SetString(HV1ProdName.Name, HV1ProdName.Text);
                Gui.SetString(HV1VersionName.Name, HV1VersionName.Text);
                Gui.SetString(HV1LocaleName.Name, HV1LocaleName.Text);

                Gui.SetString(HV2CatalogName.Name, HV2CatalogName.Text);
                Gui.SetString(HV2LocaleName.Name, HV2LocaleName.Text);

                Gui.SetBool(HV2rdo.Name, HV2rdo.Checked);

                //Kick off install
                if (!DoInstall())
                {
                    e.Cancel = true;
                    return;
                }

                //The HV2 commandline installer doesn't have a GUI. 
                if (HV2rdo.Checked)
                {
                    DialogResult ret = MessageBox.Show("Installing in background in the Windows taskbar tray.\n\nOpen Help manager?", "Installing", MessageBoxButtons.YesNo);
                    if (ret == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!OpenHelpManagerUI())
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }


            }
        }

        private void HV1ResetBtn_Click(object sender, EventArgs e)
        {
            HV1ProdName.Text = "vs";
            HV1VersionName.Text = "100";
            HV1LocaleName.Text = defaultLocale;
        }

        private void HV2ResetBtn_Click(object sender, EventArgs e)
        {
            HV2CatalogName.Text = "VisualStudio11";
            HV2LocaleName.Text = defaultLocale;
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://packagethis.codeplex.com/wikipage?title=MSHC%20Install%20Dialog");
        }

        private bool DoInstall()
        {
            string HelpManagerExePath;
            string arguments;

            if (HV2rdo.Checked)  // Help Viewer 2.0 (VS 2012)
            {
                // HlpCtntMgr.exe /operation install /catalogName VisualStudio11 /locale en-US /sourceUri "C:\Test\TestProject.msha" /vendor ""  /productName ""
                // Note that HlpCtrtMgr.exe has no GUI
                HelpManagerExePath = HV2.HelpManagerPath;
                arguments = String.Format(@"/operation install /catalogName VisualStudio11 /locale {0} /sourceUri {1}",
                    HV2LocaleName.Text, Misc.QuotedPath(MshaFileTextBox.Text));
            }
            else                 // Help Viewer 1.0 (VS 2010)
            {
                HelpManagerExePath = HV1.HelpManagerPath;
                arguments = String.Format(@"/product {0} /version {1} /locale {2} /sourceMedia {3}",
                    HV1ProdName.Text, HV1VersionName.Text, HV1LocaleName.Text, Misc.QuotedPath(MshaFileTextBox.Text));
            }

            // Install

            if (!File.Exists(HelpManagerExePath))
            {
                MessageBox.Show("File not found: " + HelpManagerExePath);
                return false;
            }

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = HelpManagerExePath;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "runas";  //run as administrator -- Required for installation
                process.Start();
            }
            catch
            {
                //User canceled the Administrator elevation prompt, or installation bad
            }
            return true;
        }


        private bool OpenHelpManagerUI()
        {
            TrimWhiteSpace();

            String HelpExe;
            String arguments;

            if (HV2rdo.Checked)
            {
                HelpExe = HV2.HlpViewerPath; //Open Help Viewer at the built-in manager page
                arguments = String.Format(@"/catalogName {0} /locale {1} /manage", HV2CatalogName.Text, HV2LocaleName.Text);
            }
            else
            {
                HelpExe = HV1.HelpManagerPath;
                arguments = String.Format(@"/product {0} /version {1} /locale {2}", HV1ProdName.Text, HV1VersionName.Text, HV1LocaleName.Text);
            }

            if (!File.Exists(HelpExe))
            {
                MessageBox.Show("File not found: " + HelpExe);
                return false;
            }

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = HelpExe;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "runas";  //run as administrator -- Required for installation
                process.Start();
            }
            catch
            {
                //User canceled the Administrator elevation prompt, or installation bad
            }
            return true;
        }


        private void helpManagerlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenHelpManagerUI();
        }

    }
}
