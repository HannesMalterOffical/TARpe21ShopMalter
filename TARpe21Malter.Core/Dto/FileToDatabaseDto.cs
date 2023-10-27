using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopMalter.Core.Dto
{
    public class FilesToDatabaseDto
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? SpaceshipId { get; set; }
    }
}
