using Microsoft.AspNetCore.Mvc;
using TARpe21ShopMalter.Core.Domain;

namespace TARpe21ShopMalter.Models.Car
{
    public class CarIndexViewModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsUsed { get; set; }

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
