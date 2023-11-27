using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopMalter.Core.Dto.WeatherDtos;

namespace TARpe21ShopMalter.Core.ServiceInterface
{
    public interface IWeatherForecastsServices
    {
        public Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
