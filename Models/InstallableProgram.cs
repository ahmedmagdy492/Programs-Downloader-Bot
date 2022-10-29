using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programs_Downloader_Bot.Models
{
    public class InstallableProgram
    {
        [Key]
        public long Id { get; set; }
        public string ProgramName { get; set; }
        public string DownloadLink { get; set; }
    }
}
