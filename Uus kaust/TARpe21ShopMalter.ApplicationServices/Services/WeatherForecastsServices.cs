﻿using Nancy;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopMalter.Core.Dto.WeatherDtos;
using TARpe21ShopMalter.Core.ServiceInterface;

namespace TARpe21ShopMalter.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apiKey=HtXsGFLFAcnYRG10m695VGkgKCAbEbZd5metric=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                weatherInfo.Headline.EffectiveDate = dto.EffectiveDate;
                weatherInfo.Headline.EffectiveEpochDate = dto.EffectiveEpochDate;
                weatherInfo.Headline.Severity = dto.Severity;
                weatherInfo.Headline.Text = dto.Text;
                weatherInfo.Headline.Category = dto.Category;
                weatherInfo.Headline.EndDate = dto.EndDate;
                weatherInfo.Headline.EndEpochDate = dto.EndEpochDate;
                weatherInfo.Headline.MobileLink = dto.MobileLink;
                weatherInfo.Headline.Link = dto.Link;

                //weatherInfo.DailyForecasts[0].Date = dto.DailyForecastsDay;
                //weatherInfo.DailyForecasts[0].EpochDate = dto.DailyForecastsEpochDate;

                weatherInfo.DailyForecasts[0].Temperature.Minimum.Value = dto.TempMinValue;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit = dto.TempMinUnit;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType = dto.TempMinUnitType;

                weatherInfo.DailyForecasts[0].Temperature.Maximum.Value = dto.TempMaxValue;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit = dto.TempMaxUnit;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType = dto.TempMaxUnitType;

                weatherInfo.DailyForecasts[0].Day.Icon = dto.DayIcon;
                weatherInfo.DailyForecasts[0].Day.IconPhrase = dto.DayIconPhrase;
                weatherInfo.DailyForecasts[0].Day.HasPrecipitation = dto.DayHasPrecipitation;
                weatherInfo.DailyForecasts[0].Day.PrecipitationType = dto.DayPrecipitationType;
                weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;

                weatherInfo.DailyForecasts[0].Night.Icon = dto.NightIcon;
                weatherInfo.DailyForecasts[0].Night.IconPhrase = dto.NightIconPhrase;
                weatherInfo.DailyForecasts[0].Night.HasPrecipitation = dto.NightHasPrecipitation;
                weatherInfo.DailyForecasts[0].Night.PrecipitationType = dto.NightPrecipitationType;
                weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity = dto.NightPrecipitationIntensity;
            }
            return dto;
        }

        public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
        {
            string apikey = "e294f7c54fe454ddfe2131bbe603db4b";
            string city = dto.City;
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={apikey}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                OpenWeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

                dto.City = weatherInfo.Name;
                dto.Timezone = weatherInfo.Timezone;
                dto.Lon = weatherInfo.Coord.Lon;
                dto.Lat = weatherInfo.Coord.Lat;
                dto.Temperature = weatherInfo.Main.Temp;
                dto.Feelslike = weatherInfo.Main.FeelsLike;
                dto.Humidity = weatherInfo.Main.Humidity;
                dto.Pressure = weatherInfo.Main.Pressure;
                dto.Speed = weatherInfo.Wind.Speed;
                dto.Description = weatherInfo.Weather[0].Description;
                dto.Main = weatherInfo.Weather[0].Main;
            }
            return dto;
        }

    }
}