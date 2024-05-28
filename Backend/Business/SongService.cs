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
    }
}
