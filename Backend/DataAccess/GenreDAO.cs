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
    public class GenreDAO
    {
        private readonly MusicalReviewsDbContext _context;
        public GenreDAO(IConfiguration config)
        {
            _context = new MusicalReviewsDbContext(config);
        }

        //post
        public async Task<Genre> CreateGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        //get
        public async Task<IEnumerable<Genre>> GetGenre()
        {
            return await _context.Genres.ToListAsync();
        }

        //get by id
        public async Task<Genre> GetGenreById(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        //put
        public async Task UpdateGenre(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        //delete
        public async Task DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
