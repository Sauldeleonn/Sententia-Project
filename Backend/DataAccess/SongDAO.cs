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
        public async Task<List<SongDetail>> GetSong()
        {
            return await _context.SongDetails.ToListAsync();
        }

        //get by id
        public async Task<SongDetail> GetSongById(int id)
        {
            return await _context.SongDetails.FindAsync(id);
        }

        //get by quantity
        public async Task<List<SongDetail>> GetSongByQuantity(int quantity)
        {
            return await _context.SongDetails.Take(quantity).ToListAsync();
        }

        //put
        public async Task UpdateSong(SongDetail song)
        {
            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        //delete doubt with the FK_ constraints that it has
        public async Task<SongDetail> DeleteSong(int id)
        {
            var song = await _context.SongDetails.FindAsync(id);
            _context.SongDetails.Remove(song);
            await _context.SaveChangesAsync();
            return song;
        }   
    }
}
