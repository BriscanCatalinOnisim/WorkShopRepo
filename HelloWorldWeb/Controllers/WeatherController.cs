// <copyright file="WeatherController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable CS1570 // XML comment has badly formed XML

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HelloWorldWeb.Controllers
{
    /// <summary>
    /// Fetch data from weather api :https://openweathermap.org/api.
    /// <see href="https://openweathermap.org/api">
    /// </summary>.
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string longitude = "23.5800";
        private readonly string latitude = "46.7700";
        private readonly string apiKey = "c39de899f75ef4e85f748679a0126376";

        public WeatherController(IWeatherControllerSettings conf)
        {
            longitude = conf.Longitude;
            latitude = conf.Latitude;
            apiKey = conf.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeather> Get()
        {
            // lat 46.7700 lon 23.5800
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=c39de899f75ef4e85f748679a0126376
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherForecastList(response.Content);
        }

        [NonAction]
        public IEnumerable<DailyWeather> ConvertResponseToWeatherForecastList(string content)
        {
            var json = JObject.Parse(content);
            if (json["daily"] == null)
            {
                throw new Exception("ApiKey is not valid!");
            }

            var jsonArray = json["daily"].Take(7);
            return jsonArray.Select(CreateDailyWeatherFromJToken);
        }

        [NonAction]
        public DailyWeather CreateDailyWeatherFromJToken(JToken item)
        {
            long unixDateTime1 = item.Value<long>("dt");
            var temperature1 = item.SelectToken("temp");
            string weather1 = item.SelectToken("weather")[0].Value<string>("description");
            DailyWeather dailyWeatherRecord = new DailyWeather();
            dailyWeatherRecord.Day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime1).DateTime.Date;
            dailyWeatherRecord.Temperature = DailyWeather.kelvinToCelsius(temperature1.Value<float>("day"));
            dailyWeatherRecord.Type = Convert(weather1);
            return dailyWeatherRecord;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "few clouds": return WeatherType.FewClouds;
                case "light rain": return WeatherType.LightRain;
                case "broken clouds": return WeatherType.BrokenClouds;
                case "scattered clouds": return WeatherType.ScatteredClouds;
                case "clear sky": return WeatherType.ClearSky;
                case "moderate rain": return WeatherType.ModerateRain;
                case "overcast clouds": return WeatherType.OvercastClouds;
                default: throw new Exception($"Unknown Weather {weather}.");
            }
        }

        /// <summary>
        /// Get a weather forecast for the day in specified amount of days from now.
        /// </summary>
        /// <param name="index">Amount of days from now (from 0 to 7).</param>
        /// <returns>The weather forecast.</returns>
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return "value";
        }

        // POST api/<WeatherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeatherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
#pragma warning restore CS1570 // XML comment has badly formed XML
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1600 // Elements should be documented
}
