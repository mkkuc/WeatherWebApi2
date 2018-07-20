using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;
using WeatherForecast.Controllers;
using WeatherForecast.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace WeatherForecast
{
    public class Tests
    {
        [Fact]
        public void IsGoodTypeNotNullGoodValuesTest()
        {
            //WeatherController testControl = new WeatherController();

            ICountry iCountry = new Country();
            OpenWeatherMap openWeather = new OpenWeatherMap(iCountry);
        
            WeatherInfo testWeather = openWeather.GetWeather("Poland", "Warsaw");
            Assert.IsType<WeatherInfo>(testWeather);

            Assert.NotNull(testWeather);

           // var contentResult = testWeather as OkNegotiatedContentResult<WeatherInfo>;

            Assert.True("Poland" == testWeather.location.country);
            Assert.True("Warsaw" == testWeather.location.city);
            Assert.True("Celsius" == testWeather.temp.format);
        }

        [Fact]
        public void NotFoundTest()
        {
            ICountry iCountry = new Country();
            OpenWeatherMap openWeather = new OpenWeatherMap(iCountry);

            WeatherInfo testWeather = openWeather.GetWeather("ABCDEF", "GHIJKLM");
            Assert.Null(testWeather);
            
        }
    }
}