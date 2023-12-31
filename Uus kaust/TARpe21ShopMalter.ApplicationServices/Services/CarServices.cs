﻿using Microsoft.EntityFrameworkCore;
using TARpe21ShopMalter.Core.Domain;
using TARpe21ShopMalter.Core.Dto;
using TARpe21ShopMalter.Core.ServiceInterface;
using TARpe21ShopMalter.Data;

namespace TARpe21ShopMalter.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly TARpe21ShopMalterContext _context;
        private readonly IFilesServices _filesServices;
        public CarServices
            (
            TARpe21ShopMalterContext context,
            IFilesServices filesServices
            )
        {
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.Id= dto.Id;
            car.Model = dto.Model;
            car.Brand= dto.Brand;
            car.Year= dto.Year;
            car.IsUsed= dto.IsUsed;
            car.CreatedAt= DateTime.Now;
            car.ModifiedAt= DateTime.Now;

            _filesServices.FilesToApi(dto, car);


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .Include(x => x.FilesToApi)
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FilesToApi
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    RealEstateId = y.RealEstateId,
                    ExistingFilePath = y.ExistingFilePath
                }).ToArrayAsync();
            await _filesServices.RemoveImagesFromApi(images);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }
        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Brand = dto.Brand;
            car.Year = dto.Year;
            car.Model= dto.Model;
            car.IsUsed = dto.IsUsed;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, car);

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
