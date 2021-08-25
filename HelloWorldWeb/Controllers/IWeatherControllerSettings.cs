// <copyright file="IWeatherControllerSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Longitude { get; }

        string Latitude { get; }

        string ApiKey { get; }
    }

#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}