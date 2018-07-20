using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{

    public class WeatherController : ApiController
    {
        public IOpenWeatherMap _openWeatherMap;
        public WeatherController(IOpenWeatherMap openWeatherMap)
        {
            _openWeatherMap = openWeatherMap;
        }
        
        [Route("{city}/{country}")]
        public IHttpActionResult GetWeather(string country, string city)
        {
            WeatherInfo weather = _openWeatherMap.GetWeather(country, city);
            if (weather != null)
                return Ok(weather);
            else return NotFound();
        }
    }
}
