using HelloWorldWeb.Controllers;
using HelloWorldWeb.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class WeatherControllerTests
    {
        private Mock<IWeatherControllerSettings> weatherMock;

        [Fact]
        public void TestCheckingConversion()
        {
           /* //Assume
            this.weatherMock = new Mock<IWeatherControllerSettings>();
            var weatherMock = this.weatherMock.Object;
            string content = LoadJsonFromResource();
            WeatherController weatherController = new WeatherController(weatherMock);

            //Act
            var result = weatherController.ConvertResponseToWeatherForecastList(content);

            //Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();
            Assert.Equal(new DateTime(2021, 8, 12), firstDay.Day);
            Assert.Equal(24.26001f, firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);*/
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.TestData.ContentFromWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
