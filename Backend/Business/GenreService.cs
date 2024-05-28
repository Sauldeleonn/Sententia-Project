using DataAccess;
using DataAccess.Repository.Entities;
using Microsoft.Extensions.Configuration;
using Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GenreService
    {
        private readonly GenreDAO _genreDAO;
        public GenreService(IConfiguration config)
        {
            _genreDAO = new GenreDAO(config);
        }

        //post method for genre using automapper
        public async Task<GenrePost_Response> PostAsync(GenrePost_Request genre)
        {
            var genreEntity = new Genre
            {
                Description = genre.Description,
                Name = genre.Name
            };
            
            var genreCreated = await _genreDAO.CreateGenre(genreEntity);

            return new GenrePost_Response { GenreId = genreCreated.GenreId};
        }
    }
}
