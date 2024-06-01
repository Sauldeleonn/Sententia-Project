using DataAccess;
using Microsoft.Extensions.Configuration;
using Models.Song;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.Entities;

namespace Business
{
    public class SongService
    {
        private readonly SongDAO _SongDAO;
        private readonly MusicalElementDAO _MusicalElementDAO;

        public SongService(IConfiguration config)
        {
            _SongDAO = new SongDAO(config);
            _MusicalElementDAO = new MusicalElementDAO(config);
        }

        //post song
        public async Task<SongPost_Response> CreateSong(SongPost_Request post_Request)//salav
        {
            //set automappers
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SongPost_Request, MusicalElement>().ReverseMap());
            var reqToElementMapper = new Mapper(config);

            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<SongPost_Request, SongDetail>().ReverseMap());
            var reqToSongMapper = new Mapper(config2);

            var config3 = new MapperConfiguration(cfg => cfg.CreateMap<SongPost_Response, SongDetail>().ReverseMap());
            var resToSongMapper = new Mapper(config3);

            var ElementReq = reqToElementMapper.Map<MusicalElement>(post_Request);
            var ElementCreated = await _MusicalElementDAO.CreateSong(ElementReq);

            var songEntity = reqToSongMapper.Map<SongDetail>(post_Request);
            songEntity.MusicalElementId = ElementCreated.MusicalElementId;

            var songCreated = await _SongDAO.CreateSong(songEntity);

            var response = resToSongMapper.Map<SongPost_Response>(songCreated);

            return response;
        }

        public async Task<SongGetAll_Response> GetSongs()
         {
            //automapper configuration
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MusicalElement, SongModel>().ReverseMap());
            var mapper = new Mapper(config);

            SongGetAll_Response response = new SongGetAll_Response();

            //map the song details to the response
            var songDetails = await _SongDAO.GetAllSongDetailsAsync();
            //and map the song release date to the response
            response.Songs = songDetails.Select(songDetail => new SongModel
            {
                MusicalElementId = songDetail.MusicalElementId,
                Name = songDetail.Name,
                Bio = songDetail.Bio,
                MusicalElementTypeId = songDetail.MusicalElementTypeId,
                ReleaseDate = songDetail.MusicalElement3.ReleaseDate
            }).ToList();

            return response;
        }

        //get song by id
        public async Task<SongGetById_Response> GetSongById(int id)
        {
            var song = await _SongDAO.GetSongById(id);

            var response = new SongGetById_Response
            {
                MusicalElementId = song.MusicalElementId,
                Name = song.Name,
                Bio = song.Bio,
                MusicalElementTypeId = song.MusicalElementTypeId,
                ReleaseDate = song.MusicalElement3.ReleaseDate
            };

            return response;
        }

        //put song
        public async Task<SongPut_Response> UpdateSong(SongPut_Request put_Request)
        {
            var musicalElement = new DataAccess.Repository.Entities.MusicalElement
            {
                MusicalElementId = put_Request.MusicalElementId,
                Name = put_Request.Name,
                Bio = put_Request.Bio,
                MusicalElementTypeId = put_Request.MusicalElementTypeId,
                MusicalElement3 = new DataAccess.Repository.Entities.SongDetail // Initialize MusicalElement3
                {
                    ReleaseDate = put_Request.ReleaseDate
                }
            };

            var result = await _SongDAO.UpdateSong(musicalElement);

            if (result == null)
            {
                return null;
            }

            var response = new SongPut_Response
            {
                MusicalElementId = result.MusicalElementId
            };

            return response;
        }

        //delete song   
        public async Task<SongDelete_Response> DeleteSong(int id)
        {
            var response = await _SongDAO.DeleteSong(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SongDetail, SongDelete_Response>().ReverseMap());
            var mapper = new Mapper(config);

            var responseModel = mapper.Map<SongDelete_Response>(response);

            return responseModel;
        }
    }
}
