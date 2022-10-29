using Programs_Downloader_Bot.Data;
using Programs_Downloader_Bot.Models;
using Programs_Downloader_Bot.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Programs_Downloader_Bot
{
    public partial class UpdateProgramForm : Form
    {
        private readonly InstallProgramRepo installProgramRepo;
        private readonly long _programId;
        private InstallableProgram installableProgram;

        public UpdateProgramForm(long programId)
        {
            installProgramRepo = new InstallProgramRepo(AppDBContext.GetInstance());
            InitializeComponent();
            _programId = programId;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtProgName.Text))
            {
                MessageBox.Show("Please Enter Program Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLink.Text) || !Uri.IsWellFormedUriString(txtLink.Text, UriKind.Absolute))
            {
                MessageBox.Show("Please Enter a Valid Link");
                return false;
            }

            return true;
        }

        private async void UpdateProgramForm_Load(object sender, EventArgs e)
        {
            installableProgram = await installProgramRepo.GetById(_programId);
            txtLink.Text = installableProgram.DownloadLink;
            txtProgName.Text = installableProgram.ProgramName;
        }

        private async void btnUpdateProgram_Click_1(object sender, EventArgs e)
        {
            bool validationResult = ValidateData();

            if (validationResult)
            {
                installableProgram.DownloadLink = txtLink.Text;
                installableProgram.ProgramName = txtProgName.Text;
                installProgramRepo.UpdateProgram(installableProgram);

                bool result = await installProgramRepo.SaveChanges();
                if (result)
                    MessageBox.Show("Program is Updated Successfully");
                else
                    MessageBox.Show("Program is not Updated due to a problem");
                this.Close();
            }
        }
    }
}
