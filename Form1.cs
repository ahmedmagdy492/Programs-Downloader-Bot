using Programs_Downloader_Bot.Data;
using Programs_Downloader_Bot.Helpers;
using Programs_Downloader_Bot.Models;
using Programs_Downloader_Bot.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programs_Downloader_Bot
{
    public partial class Form1 : Form
    {
        private readonly InstallProgramRepo installProgramRepo;

        public Form1()
        {
            installProgramRepo = new InstallProgramRepo(AppDBContext.GetInstance());
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAddProgram_Click(object sender, EventArgs e)
        {
            AddProgram addProgram = new AddProgram();
            addProgram.ShowDialog();
            dataGridView1.DataSource = await installProgramRepo.GetPrograms();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Properties.Resources.DownloadSavePath))
            {
                Properties.Settings.Default.DownloadSavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Properties.Settings.Default.Save();
            }

            dataGridView1.DataSource = await installProgramRepo.GetPrograms();
        }

        private void btnInstallSelected_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                new LoadingForm(GetSelectedInstallablePrograms()).ShowDialog();
            }
        }

        private List<InstallableProgram> GetSelectedInstallablePrograms()
        {
            List<InstallableProgram> installablePrograms = new List<InstallableProgram>();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    var program = new InstallableProgram
                    {
                        ProgramName = item.Cells[1].Value.ToString(),
                        DownloadLink = item.Cells[2].Value.ToString()
                    };
                    installablePrograms.Add(program);
                }
            }

            return installablePrograms;
        }

        private List<InstallableProgram> GetAllInstallablePrograms()
        {
            List<InstallableProgram> installablePrograms = new List<InstallableProgram>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                var program = new InstallableProgram
                {
                    ProgramName = item.Cells[1].Value.ToString(),
                    DownloadLink = item.Cells[2].Value.ToString()
                };
                installablePrograms.Add(program);
            }

            return installablePrograms;
        }

        private async void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(dataGridView1.SelectedRows.Count == 1)
                {
                    long id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value);
                    var installableProgram = await installProgramRepo.GetById(id);
                    installProgramRepo.DeleteProgram(installableProgram);
                    await installProgramRepo.SaveChanges();
                    dataGridView1.DataSource = await installProgramRepo.GetPrograms();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                deleteSelectedToolStripMenuItem.Enabled = true;
                updateSelectedToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteSelectedToolStripMenuItem.Enabled = false;
                updateSelectedToolStripMenuItem.Enabled = false;
            }
        }

        private void btnInstallAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm this Action Install All Programs?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                new LoadingForm(GetAllInstallablePrograms()).ShowDialog();
            }
        }

        private void btnInstallFromDisk_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.Filter = "exe or msi(*.exe;*.msi)|*.exe;*.msi";
                opf.FilterIndex = 2;
                opf.Multiselect = true;
                opf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                opf.RestoreDirectory = true;
                var result = opf.ShowDialog();
                if(result == DialogResult.OK)
                {
                    foreach(var file in opf.FileNames)
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = file;
                        process.Start();
                    }
                }
            }
        }

        private void reportAProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReportProblemForm().ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().Show();
        }

        private async void updateSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                long id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value);
                new UpdateProgramForm(id).ShowDialog();
                dataGridView1.DataSource = await installProgramRepo.GetPrograms();
            }
        }
    }
}
