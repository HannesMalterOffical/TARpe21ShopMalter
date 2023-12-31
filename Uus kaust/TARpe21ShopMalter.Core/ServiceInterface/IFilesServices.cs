﻿using TARpe21ShopMalter.Core.Domain;
using TARpe21ShopMalter.Core.Dto;

namespace TARpe21ShopMalter.ApplicationServices.Services
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);

        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
        void FilesToApi(RealEstateDto dto, RealEstate realEstate);
        void FilesToApi(CarDto dto, Car car);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);

    }
}