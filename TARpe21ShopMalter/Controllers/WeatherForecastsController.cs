using Microsoft.AspNetCore.Mvc;

namespace TARpe21ShopMalter.Controllers
{
    public class WeatherForecastsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
