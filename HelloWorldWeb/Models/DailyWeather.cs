using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace HelloWorldWeb.Models
{
    public class DailyWeather
    {
        public DailyWeather(DateTime day, float temperature, WeatherType type)
        {
            Day = day;
            Temperature = temperature;
            Type = type;
        }

        public DailyWeather()
        {
        }

        public static float kelvinToCelsius(float temp)
        {
            return temp - KELVIN_CONST;
        }

        public const float KELVIN_CONST = 273.15f;
        public float Temperature { get; set; }
        public WeatherType Type { get; set; }
        public DateTime Day { get; set; }
    }
}
