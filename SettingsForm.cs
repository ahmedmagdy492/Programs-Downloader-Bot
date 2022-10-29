using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Programs_Downloader_Bot
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtFilePath.Text = Properties.Settings.Default.DownloadSavePath;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = Properties.Settings.Default.DownloadSavePath;
                var result = fbd.ShowDialog();
                if(result == DialogResult.OK)
                {
                    txtFilePath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DownloadSavePath = txtFilePath.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
