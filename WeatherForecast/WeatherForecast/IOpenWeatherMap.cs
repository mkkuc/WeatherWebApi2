using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherForecast.Models;

namespace WeatherForecast
{
    public interface IOpenWeatherMap
    {
        WeatherInfo GetWeather(string country, string city);
    }
}
