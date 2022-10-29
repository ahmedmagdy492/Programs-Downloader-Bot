using Microsoft.VisualBasic;
using Programs_Downloader_Bot.Models;
using Programs_Downloader_Bot.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Programs_Downloader_Bot.Helpers
{
    public static class ProgramDownloader
    {
        public async static Task DownloadAndInstall(InstallableProgram program)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(program.DownloadLink);

                var response = await httpClient.GetAsync("");
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception(content);
                }
                
                var stream = await response.Content.ReadAsStreamAsync();

                using(var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    string fileName = Path.GetFileName(program.DownloadLink);
                    string fullPath = Path.Combine(Properties.Settings.Default.DownloadSavePath, fileName);

                    File.WriteAllBytes(fullPath, ms.ToArray());

                    Process process = new Process();
                    process.StartInfo.FileName = fullPath;
                    process.Start();
                }
            }
        }
    }
}
