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
            WeatherController testControl = new WeatherController();

            IHttpActionResult testWeather = testControl.Get("Poland", "Warsaw");
            Assert.IsType<OkNegotiatedContentResult<WeatherInfo>>(testWeather);

            Assert.NotNull(testWeather);

            var contentResult = testWeather as OkNegotiatedContentResult<WeatherInfo>;

            Assert.True("Poland" == contentResult.Content.location.country);
            Assert.True("Warsaw" == contentResult.Content.location.city);
            Assert.True("Celsius" == contentResult.Content.temp.format);
        }

        [Fact]
        public void NotFoundTest()
        {
            WeatherController testControl = new WeatherController();

            IHttpActionResult testWeather = testControl.Get("ABCDEF", "GHIJKLM");
            Assert.IsType<NotFoundResult>(testWeather);
            
        }
    }
}