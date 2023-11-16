using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopMalter.Core.Domain;

namespace TARpe21ShopMalter.Data
{
    public class TARpe21ShopMalterContext : DbContext
    {
        public TARpe21ShopMalterContext(DbContextOptions<TARpe21ShopMalterContext> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FileToApi> FilesToApi { get; set; }
    }
}
