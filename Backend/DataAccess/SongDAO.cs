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
    public class SongDAO
    {
        private readonly MusicalReviewsDbContext _context;

        public SongDAO(IConfiguration config)
        {
            _context = new MusicalReviewsDbContext(config);
        }

        //post
        public async Task<SongDetail> CreateSong(SongDetail song)
        {
            _context.SongDetails.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        //get
        public async Task<List<MusicalElement>> GetAllSongDetailsAsync()
        {
            return await _context.MusicalElements
                .Include(me => me.MusicalElement3) // Includes the SongDetail related to MusicalElement
                .Where(me => me.MusicalElement3 != null) // Filters out only those with SongDetail
                .ToListAsync();
        }

        //get by id
        public async Task<MusicalElement> GetSongById(int id)
        {
            var song = await _context.SongDetails.FindAsync(id);
            if (song == null)
            {
                return null;
            }

            var result = await _context.MusicalElements
                .Include(me => me.MusicalElement3) // Includes the SongDetail related to MusicalElement
                .Where(me => me.MusicalElement3 != null) // Filters out only those with SongDetail
                .FirstOrDefaultAsync(me => me.MusicalElementId == id);

            return result;
        }

        //get by quantity
        public async Task<List<SongDetail>> GetSongByQuantity(int quantity)
        {
            return await _context.SongDetails.Take(quantity).ToListAsync();
        }

        //put
        public async Task<MusicalElement> UpdateSong(MusicalElement musicalElement)
        {
            SongDetail song = await _context.SongDetails.FindAsync(musicalElement.MusicalElementId);
            if (song == null){  return null; }

            song.ReleaseDate = musicalElement.MusicalElement3.ReleaseDate;
            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            _context.Entry(musicalElement).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return musicalElement;
        }


        //delete doubt with the FK_ constraints that it has
        public async Task<SongDetail> DeleteSong(int id)
        {
            var song = await _context.SongDetails.FindAsync(id);
            _context.SongDetails.Remove(song);
            await _context.SaveChangesAsync();

            var musicalElement = await _context.MusicalElements.FindAsync(id);
            _context.MusicalElements.Remove(musicalElement);
            await _context.SaveChangesAsync();

            return song;
        }   
    }
}
