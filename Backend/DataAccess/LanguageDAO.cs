using DataAccess.Repository;
using DataAccess.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LanguageDAO
    {
        private readonly MusicalReviewsDbContext _context;
        public LanguageDAO(IConfiguration config)
        {
            _context = new MusicalReviewsDbContext(config);
        }

        //post
        public async Task<Language> CreateLanguage(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
            return language;
        }

        //get
        public async Task<IEnumerable<Language>> GetLanguage()
        {
            return await _context.Languages.ToListAsync();
        }

        //get by id
        public async Task<Language> GetLanguageById(int id)
        {
            return await _context.Languages.FindAsync(id);
        }

        //put
        public async Task UpdateLanguage(Language language)
        {
            _context.Entry(language).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        //delete
        public async Task<Language> DeleteLanguage(int id)
        {
            var language = await _context.Languages.FindAsync(id);
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
            return language;
        }   
    }
}
