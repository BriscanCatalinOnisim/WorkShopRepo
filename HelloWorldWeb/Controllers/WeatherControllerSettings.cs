// <copyright file="WeatherControllerSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Controllers;
using Microsoft.Extensions.Configuration;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1101 // Prefix local calls with this

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

#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}