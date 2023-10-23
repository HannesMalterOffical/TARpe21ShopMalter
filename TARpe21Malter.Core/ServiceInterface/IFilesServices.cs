using TARpe21ShopMalter.Core.Domain.Spaceship;
using TARpe21ShopMalter.Core.Dto;

namespace TARpe21ShopMalter.ApplicationServices.Services
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
    }
}