using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PackageThis
{
    public partial class ScheduleForm : Form
    {
        private TreeNode startingNode;
        private Content contentDataSet;
        private MtpsNode mtpsNode;

        public struct ScheduleReturnData
        {
            public Boolean Enabled;
            public Boolean xStart;
            public Boolean xStop;
            public Boolean xStopAfter;
            public DateTime StartDate;
            public DateTime StartTime;
            public DateTime StopDate;
            public DateTime StopTime;
            public int StopAfter;
        }

        public static ScheduleReturnData sData;

        public ScheduleForm(TreeNode node, Content contentDataSet)
        {
            this.startingNode = node;
            this.contentDataSet = contentDataSet;
            this.mtpsNode = node.Tag as MtpsNode;

            InitializeComponent();

            DownloadNodeLabel.Text = mtpsNode.title;
            StartDate.Value = DateTime.Today;
            StartTime.Value = DateTime.Now;
            StopDate.Value = DateTime.Today;
            StopTime.Value = DateTime.Now;

            StartDate.MinDate = DateTime.Now.Date;
            StopDate.MinDate = DateTime.Now.Date;

            //adjust controls for Large Font Display -- Why is this necessary? (Its not on the download dialog)
            DownloadNodeLabel.Left = Label1.Left + Label1.Width + 5;
            StopAfterNum.Left = StopAfterCbx.Left + StopAfterCbx.Width + 5;
            downloadLabel.Left = StopAfterNum.Left + StopAfterNum.Width + 5;

            sData.Enabled = false;
            InfoPanel.Visible = false;
            EnableDisable();
        }

        private void EnableDisable()
        {
            StartDate.Enabled = StartCbx.Checked;
            StartTime.Enabled = StartCbx.Checked;
            StopDate.Enabled = StopCbx.Checked;
            StopTime.Enabled = StopCbx.Checked;
            StopAfterNum.Enabled = StopAfterCbx.Checked;
        }

        private void AnyCheckBox_Changed(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void ScheduleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sData.Enabled = false;

            if (this.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                sData.Enabled = true;
            }

            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Return data
                sData.Enabled = true;
                sData.xStart = StartCbx.Checked;
                sData.xStop = StopCbx.Checked;
                sData.xStopAfter = StopAfterCbx.Checked;
                sData.StartDate = StartDate.Value;
                sData.StartTime = StartTime.Value;
                sData.StopDate = StopDate.Value;
                sData.StopTime = StopTime.Value;
                sData.StopAfter = (int)StopAfterNum.Value;

                //Wait until Scheduled start

                if (!ReadyToStart)
                {
                    e.Cancel = true;
                    InfoPanel.Visible = true;
                    timer1.Enabled = true;
                }
            }
        }

        private bool ReadyToStart
        {
            get
            {
                DisplayCounter();

                bool fRet = false;
                if (!sData.xStart)   //Start Date not checked? -- We can start immediately!
                    fRet = true;

                if (!fRet)  //Date & Time Expired?
                {
                    if ((int)_dt.TotalDays < 0)  //It's next day
                        fRet = true;

                    if ((int)_dt.TotalDays == 0)  //Day match
                    {
                        if ((int)_dt.TotalSeconds <= 0)  //Current time >= start time 
                            fRet = true;
                    }
                }

                return fRet;
            }
        }

        TimeSpan _dt;

        private void DisplayCounter()
        {
            TimeSpan dateDiff = sData.StartDate.Subtract(DateTime.Today);
            TimeSpan timeDiff = sData.StartTime.Subtract(DateTime.Now);
            _dt = dateDiff.Add(timeDiff);

            String s = "";
            if ((int)_dt.TotalDays > 0)
                s += ((int)_dt.TotalDays).ToString() + " days; ";
            if ((int)_dt.TotalSeconds > 0)
                s +=
                     _dt.Hours.ToString() + ":"
                    + _dt.Minutes.ToString() + ":"
                    + _dt.Seconds.ToString();

            StartTimeLabel.Text = s;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ReadyToStart)
            {
                this.DialogResult = DialogResult.Yes;   //close()
            }
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://packagethis.codeplex.com/wikipage?title=Schedule");
        }



    }
}
