// <copyright file="DailyWeather.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1310 // Field names should not contain underscore
#pragma warning disable SA1300 // Element should begin with upper-case letter

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
#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore SA1310 // Field names should not contain underscore
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1600 // Elements should be documented
}
