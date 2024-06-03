using AutoMapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Models.MusicalElementType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MusicalElementTypeService
    {
        private readonly MusicalElementTypeDAO _DAO;
        public MusicalElementTypeService(IConfiguration configuration)
        {
            _DAO = new MusicalElementTypeDAO(configuration);
        }

        public async Task<MusicalElementTypeGetAll_Response> GetAllAsync()
        {
            //set the autommaper to pass the data from the model to the response
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MusicalElementTypeModel, DataAccess.Repository.Entities.MusicalElementType>().ReverseMap();
            });
            Mapper mapper = new Mapper(config);

            var response = new MusicalElementTypeGetAll_Response();
            
            List<MusicalElementTypeModel> MusicalElementTypes;

            List<DataAccess.Repository.Entities.MusicalElementType> typesReturned = await _DAO.GetAllMusicalElementTypesAsync();

            MusicalElementTypes = typesReturned.Select(x => mapper.Map<MusicalElementTypeModel>(x)).ToList();

            response.MusicalElementTypes = MusicalElementTypes;

            return response;
        }
    }
}
