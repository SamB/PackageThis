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
    public partial class ExpandProgressForm : Form
    {
        private int nodeCount;
        private TreeNode node;
        private TreeNode startingNode;
        private bool decendingTree;

        public ExpandProgressForm(TreeNode node)
        {
            this.startingNode = node;
            this.node = node;
            this.decendingTree = true;
            this.nodeCount = 0;

            InitializeComponent();

            timer1.Enabled = true;
        }

        bool _InTimer = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_InTimer)
            {
                MessageBox.Show("Reentrant Code xxx1");
                return;     //Actually code never enters here so this shows that C# timer events are NOT reenterent by default
            }

            _InTimer = true;
            try
            {
                if (node == null)
                {
                    timer1.Enabled = false;
                    this.Close();
                    return;
                }

                node.Expand();  //This triggers Tree control event (before expand)

                //status display
                nodeCount = nodeCount + node.Nodes.Count;
                CountLabel.Text = nodeCount.ToString();

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
            finally
            {
                _InTimer = false;
            }
        }

        private void RequestCancelButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void ExpandProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

    }
}