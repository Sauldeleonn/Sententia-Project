using AutoMapper;
using DataAccess;
using DataAccess.Repository.Entities;
using Microsoft.Extensions.Configuration;
using Models.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LanguageService
    {
        private readonly LanguageDAO _languageDAO;

        public LanguageService(IConfiguration configuration)
        {
            _languageDAO = new LanguageDAO(configuration);
        }

        //post
        public async Task<LanguagePost_Response> PostLanguage(LanguagePost_Request request)
        {
            //set auto mapper
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LanguagePost_Request, Language>().ReverseMap(); });
            var RequestMapper = new Mapper(config);

            var MapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<Language, LanguagePost_Response>().ReverseMap(); });
            var ResponseMapper = new Mapper(MapperConfig);

            var languageEntity = RequestMapper.Map<Language>(request);

            var languageCreated = await _languageDAO.CreateLanguage(languageEntity);
            var languageResponse = ResponseMapper.Map<LanguagePost_Response>(languageCreated);

            return languageResponse;
        }

        //get all
        public async Task<LanguageGetAll_Response> GetLanguages()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Language, LanguageModel>().ReverseMap(); });
            var ResponseMapper = new Mapper(config);

            var languages = await _languageDAO.GetLanguage();
            var languagesResponse = ResponseMapper.Map<List<LanguageModel>>(languages);

            LanguageGetAll_Response response = new LanguageGetAll_Response()
            {
                Languages = languagesResponse
            };

            return response;
        }

        //get by id
        public async Task<LanguageGetById_Response> GetLanguageById(int id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Language, LanguageGetById_Response>().ReverseMap(); });
            var ResponseMapper = new Mapper(config);

            var language = await _languageDAO.GetLanguageById(id);
            var languageResponse = ResponseMapper.Map<LanguageGetById_Response>(language);

            return languageResponse;
        }

        //put
        public async Task<LanguageModel> UpdateLanguage(LanguageModel language)
        {
            //set auto mapper
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Language, LanguageModel>().ReverseMap(); });
            var RequestMapper = new Mapper(config);

            var languageEntity = RequestMapper.Map<Language>(language);

            await _languageDAO.UpdateLanguage(languageEntity);

            //get the updated language
            var updatedLanguage = await _languageDAO.GetLanguageById(language.LanguageId);

            var response = RequestMapper.Map<LanguageModel>(updatedLanguage);


            return response;
        }

        //delete
        public async Task<LanguageDelete_Response> DeleteLanguage(int id)
        {
            //set auto mapper
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LanguageDelete_Response, Language>().ReverseMap(); });
            var RequestMapper = new Mapper(config);

            var language = await _languageDAO.DeleteLanguage(id);

            var response = RequestMapper.Map<LanguageDelete_Response>(language);
            return response;

        }
    }
}
