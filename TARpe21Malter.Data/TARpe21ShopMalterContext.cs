using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopMalter.Core.Domain.Spaceship;

namespace TARpe21ShopMalter.Data
{
    public class TARpe21ShopMalterContext : DbContext
    {
        public TARpe21ShopMalterContext(DbContextOptions<TARpe21ShopMalterContext> options) : base(options) { }

        public DbSet<Spaceship> spaceships { get; set; }
    }
}
