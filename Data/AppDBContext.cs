using Microsoft.EntityFrameworkCore;
using Programs_Downloader_Bot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Programs_Downloader_Bot.Data
{
    public class AppDBContext : DbContext
    {
        private AppDBContext()
        {
        }

        private static AppDBContext _appDBContext;

        public static AppDBContext GetInstance()
        {
            if(_appDBContext == null)
                _appDBContext = new AppDBContext();
            return _appDBContext;
        }

        public DbSet<InstallableProgram> InstallablePrograms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=mydb.db;");
        }
    }
}
