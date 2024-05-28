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
    public class MusicalElementDAO
    {
        private readonly MusicalReviewsDbContext _context;

        public MusicalElementDAO(IConfiguration config)
        {
            _context = new MusicalReviewsDbContext(config);
        }

        //post
        public async Task<MusicalElement> CreateSong(MusicalElement element)
        {
            _context.MusicalElements.Add(element);
            await _context.SaveChangesAsync();
            return element;
        }

        //get
        public async Task<List<MusicalElement>> GetMusicalElement()
        {
            return await _context.MusicalElements.ToListAsync();
        }

        //get by id
        public async Task<MusicalElement> GetMusicalElementById(int id)
        {
            return await _context.MusicalElements.FindAsync(id);
        }

        //get by quantity
        public async Task<List<MusicalElement>> GetMusicalElementByQuantity(int quantity)
        {
            return await _context.MusicalElements.Take(quantity).ToListAsync();
        }

        //put
        public async Task UpdateMusicalElement(MusicalElement element)
        {
            _context.Entry(element).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        //delete doubt with the FK_ constraints that it has
        public async Task<MusicalElement> DeleteMusicalElement(int id)
        {
            var element = await _context.MusicalElements.FindAsync(id);
            _context.MusicalElements.Remove(element);
            await _context.SaveChangesAsync();
            return element;
        }
    }
}
