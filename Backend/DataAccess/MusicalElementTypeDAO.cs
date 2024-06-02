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
    public class MusicalElementTypeDAO
    {
        private readonly MusicalReviewsDbContext _context;

        public MusicalElementTypeDAO(IConfiguration config)
        {
            _context = new MusicalReviewsDbContext(config);
        }

        //get
        public async Task<List<MusicalElementType>> GetAllMusicalElementTypesAsync()
        {
            return await _context.MusicalElementTypes.ToListAsync();
        }
    }
}
