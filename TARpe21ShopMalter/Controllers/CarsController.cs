using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe21ShopMalter.ApplicationServices.Services;
using TARpe21ShopMalter.Core.Domain;
using TARpe21ShopMalter.Core.Dto;
using TARpe21ShopMalter.Core.ServiceInterface;
using TARpe21ShopMalter.Data;
using TARpe21ShopMalter.Models.Car;
using TARpe21ShopMalter.Models.File;

namespace TARpe21ShopMalter.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARpe21ShopMalterContext _context;
        private readonly ICarServices _cars;
        private readonly IFilesServices _filesServices;

        public CarsController (TARpe21ShopMalterContext context, ICarServices cars, IFilesServices filesServices)
        {
            _context = context;
            _cars = cars;
            _filesServices = filesServices;
        }


        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiViewModel vm)
        {
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId
            };
            var image = await _filesServices.RemoveImageFromApi(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderBy(x => x.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Year = x.Year,
                    Mileage = x.Mileage,
                    IsUsed = x.IsUsed 
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = Guid.NewGuid(),
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                Mileage = vm.Mileage,
                IsUsed = vm.IsUsed,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FilesToApiDtos = vm.FileToApiViewModels
                .Select(z => new FileToApiDto
                {
                    Id = z.ImageId,
                    ExistingFilePath = z.FilePath,
                    CarId = z.CarId,
                }).ToArray()

            };
            var result = await _cars.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Mileage = car.Mileage;
            vm.IsUsed = car.IsUsed;
            vm.FileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = (Guid)vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                Year = vm.Year,
                Mileage = vm.Mileage,
                IsUsed = vm.IsUsed,
                Files = vm.Files,
                FilesToApiDtos = vm.FileToApiViewModels
                .Select(z => new FileToApiDto
                {
                    Id = z.ImageId,
                    ExistingFilePath = z.FilePath,
                    CarId = z.CarId,
                }).ToArray()
            };
            var result = await _cars.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarDetailsDeleteViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Mileage = car.Mileage;
            vm.IsUsed = car.IsUsed;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.isDeleting = false;
            vm.FileToApiViewModels.AddRange(images);

            return View("DetailsDelete", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarDetailsDeleteViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Mileage = car.Mileage;
            vm.IsUsed = car.IsUsed;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.isDeleting = true;
            vm.FileToApiViewModels.AddRange(images);

            return View("DetailsDelete", vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var car = await _cars.Delete(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
