using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TARpe21ShopMalter.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            List<string> makes = new List<string>()
            {
                "Abbey",
                "AC",
                "Ackermann Fruehauf",
                "Acura",
                "Alfa Romeo",
                "Alpina",
                "Alpine",
                "Apollo",
                "Arctic Cat",
                "Astra",
                "Citroen",
                "Cupra",
                "Dacia",
                "Cobalt",
                "Tesla",
                "Ford",
                "Mustang",
                "Honda",
                "Jaguar"
            };
            ViewBag.Makes = new SelectList(makes);
            return View();
        }
    }
}
