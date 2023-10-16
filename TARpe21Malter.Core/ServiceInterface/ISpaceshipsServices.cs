using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21Malter.Core.Dto;
using TARpe21ShopMalter.Core.Domain.Spaceship;


namespace TARpe21ShopMalter.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Add(SpaceshipDto dto);
    }
}