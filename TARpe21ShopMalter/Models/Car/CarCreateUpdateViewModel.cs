using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TARpe21ShopMalter.Core.Domain;
using TARpe21ShopMalter.Models.File;

namespace TARpe21ShopMalter.Models.Car
{
    public class CarCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public List<SelectListItem> BrandOptions { get; set; } = new List<SelectListItem>() {
        new SelectListItem { Text = "", Value = "" },
        new SelectListItem { Text = "Toyota", Value = "Toyota" },
        new SelectListItem { Text = "Honda", Value = "Honda" },
        new SelectListItem { Text = "Ford", Value = "Ford" },
        new SelectListItem { Text = "Chevrolet", Value = "Chevrolet" },
        new SelectListItem { Text = "Nissan", Value = "Nissan" },
        new SelectListItem { Text = "BMW", Value = "BMW" },
        new SelectListItem { Text = "Mercedes-Benz", Value = "Mercedes-Benz" },
        new SelectListItem { Text = "Volkswagen", Value = "Volkswagen" },
        new SelectListItem { Text = "Audi", Value = "Audi" },
        new SelectListItem { Text = "Subaru", Value = "Subaru" },
        new SelectListItem { Text = "Hyundai", Value = "Hyundai" },
        new SelectListItem { Text = "Kia", Value = "Kia" }
    };
        public string Model { get; set; }
        public int Year { get; set; }
        public int EnginePowerKW { get; set; }
        public int? Mileage { get; set; }
        public bool IsUsed { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
