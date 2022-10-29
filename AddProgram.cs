using Programs_Downloader_Bot.Data;
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
    public partial class AddProgram : Form
    {
        private readonly InstallProgramRepo installProgramRepo;

        public AddProgram()
        {
            installProgramRepo = new InstallProgramRepo(AppDBContext.GetInstance());
            InitializeComponent();
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

        private async void btnAddProgram_Click(object sender, EventArgs e)
        {
            bool validationResult = ValidateData();

            if(validationResult)
            {
                installProgramRepo.AddProgram(new Models.InstallableProgram
                {
                    ProgramName = txtProgName.Text,
                    DownloadLink = txtLink.Text,
                });

                bool result = await installProgramRepo.SaveChanges();
                if(result)
                    MessageBox.Show("Program is Added Successfully");
                else
                    MessageBox.Show("Program is not Added due to a problem");
            }
        }
    }
}
