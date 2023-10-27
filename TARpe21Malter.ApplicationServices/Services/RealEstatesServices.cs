using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TARpe21ShopMalter.Core.Domain;
using TARpe21ShopMalter.Data;

namespace TARpe21ShopMalter.ApplicationServices.Services
{
    public class RealEstatesServices
    {
        private readonly TARpe21ShopMalterContext _context;
        public RealEstatesServices
            (
            TARpe21ShopMalterContext context
            )
        {
            _context = context;
        }

        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.id == id);
            return result;
        }
    }
}
