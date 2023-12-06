using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TARpe21ShopMalter.Core.ServiceInterface;
using TARpe21ShopMalter.Core.Dto.WeatherDtos;
using TARpe21ShopMalter.Core.ServiceInterface;
using TARpe21ShopMalter.Models.OpenWeather;
using TARpe21ShopMalter.Core.ServiceInterface;

namespace TARpe21ShopMalter.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IWeatherForecastsServices _openWeatherServices;
        public OpenWeatherController(IWeatherForecastsServices weatherForecastServices)
        {
            _openWeatherServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            OpenWeatherViewModel vm = new OpenWeatherViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather()
        {
            string city = Request.Form["City"];

            if (!string.IsNullOrEmpty(city))
            {
                OpenWeatherResultDto dto = new();
                dto.City = city;
                _openWeatherServices.OpenWeatherDetail(dto);

                OpenWeatherViewModel vm = new()
                {
                    City = dto.City,
                    Timezone = dto.Timezone,
                    Temperature = dto.Temperature,
                    Pressure = dto.Pressure,
                    Humidity = dto.Humidity,
                    Main = dto.Main,
                    Description = dto.Description,
                    Speed = dto.Speed
                };

                return View("City", vm);
            }

            return View();
        }
    }
}
