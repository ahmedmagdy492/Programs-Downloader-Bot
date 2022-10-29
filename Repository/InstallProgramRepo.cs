using Microsoft.EntityFrameworkCore;
using Programs_Downloader_Bot.Data;
using Programs_Downloader_Bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programs_Downloader_Bot.Repository
{
    public class InstallProgramRepo
    {
        private readonly AppDBContext _context;

        public InstallProgramRepo(AppDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<InstallableProgram>> GetPrograms()
        {
            return await _context.InstallablePrograms.ToListAsync();
        }

        public async Task<InstallableProgram> GetById(long id)
        {
            return await _context.InstallablePrograms.FirstOrDefaultAsync(u => u.Id == id);
        }

        public void AddProgram(InstallableProgram program)
        {
            _context.InstallablePrograms.Add(program);
        }

        public void UpdateProgram(InstallableProgram program)
        {
            _context.Entry(program).State = EntityState.Modified;
        }

        public void DeleteProgram(InstallableProgram program)
        {
            _context.Entry(program).State = EntityState.Deleted;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
