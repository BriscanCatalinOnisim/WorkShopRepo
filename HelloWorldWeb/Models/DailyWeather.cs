using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public float Temperature { get; set; }
        public WeatherType Type { get; set; }
        public DateTime Day { get; set; }
    }
}
