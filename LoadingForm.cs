using Programs_Downloader_Bot.Helpers;
using Programs_Downloader_Bot.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Programs_Downloader_Bot
{
    public partial class LoadingForm : Form
    {
        private List<InstallableProgram> _installablePrograms = new List<InstallableProgram>();
        public LoadingForm(List<InstallableProgram> installablePrograms)
        {
            _installablePrograms = installablePrograms;
            InitializeComponent();
        }

        private async void LoadingForm_Load(object sender, EventArgs e)
        {
            int currentProgram = 0;
            progressBar1.Maximum = 100;
            foreach (var installableProgram in _installablePrograms)
            {
                currentProgram++;
                lblProgress.Text = $"Downloading Program {installableProgram.ProgramName} out of {_installablePrograms.Count}";
                progressBar1.Value = currentProgram / _installablePrograms.Count * 100;
                try
                {
                    await ProgramDownloader.DownloadAndInstall(installableProgram);
                    MessageBox.Show($"Program {installableProgram.ProgramName} is Downloaded Successfuly");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Problem with Link of Program {installableProgram.ProgramName}: {ex.Message}");
                    currentProgram--;
                }
            }

            MessageBox.Show($"Downloaded {currentProgram} out of {_installablePrograms.Count}");
            this.Close();
        }
    }
}
