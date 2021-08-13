using HelloWorldWeb.Controllers;
using Microsoft.Extensions.Configuration;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration configuration)
        {
            ApiKey = configuration["WeatherForecast:ApiKey"];
            Longitude = configuration["WeatherForecast:Longitude"];
            Latitude = configuration["WeatherForecast:Latitude"];

        }

        public string Longitude { get; set;  }

        public string Latitude { get; set; }

        public string ApiKey { get; set; }
    }
}