using DataAccess;
using DataAccess.Repository.Entities;
using Microsoft.Extensions.Configuration;
using Models.Genre;
using AutoMapper;

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
        public async Task<GenrePost_Response> PostAsync(GenrePost_Request genrePostRequest)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<GenrePost_Request, Genre>().ReverseMap(); });
            var RequestMapper = new Mapper(config);

            var MapperConfig = new MapperConfiguration(cfg =>{  cfg.CreateMap<Genre, GenrePost_Response>().ReverseMap(); });
            var ResponseMapper = new Mapper(MapperConfig);

            var genreEntity = RequestMapper.Map<Genre>(genrePostRequest);
            
            var genreCreated = await _genreDAO.CreateGenre(genreEntity);

            var genreResponse = ResponseMapper.Map<GenrePost_Response>(genreCreated);

            

            return genreResponse;/*new GenrePost_Response { GenreId = genreCreated.GenreId}*/
        }

        public async Task<List<GenreGet_Response>> GetGenresAsync()
        {
            //get all genres
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Genre, GenreGet_Response>().ReverseMap(); });
            var ResponseMapper = new Mapper(config);

            var genres = await _genreDAO.GetGenre();
           
            var genresResponse = ResponseMapper.Map<List<GenreGet_Response>>(genres);
            return genresResponse;
        }

        public async Task<GenreGet_Response> GetGenreByIdAsync(int id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Genre, GenreGet_Response>().ReverseMap(); });
            var ResponseMapper = new Mapper(config);

            var genre = await _genreDAO.GetGenreById(id);
            var genreResponse = ResponseMapper.Map<GenreGet_Response>(genre);

            return genreResponse;


        }

        public Task DeleteGenreAsync(int id)
        {
            return _genreDAO.DeleteGenre(id);
        }
    }
}
