using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WeatherForecast.Models;


namespace WeatherForecast
{
    public class OpenWeatherMap : IOpenWeatherMap
    {

        private ICountry _ICountry;
        public OpenWeatherMap(ICountry iCountry)
        {
            _ICountry = iCountry;
        }

        public WeatherInfo GetWeather(string country, string city)
        {
            string url;
            string response;
            string countryCode;

            try
            {
                countryCode = _ICountry.GetCountryCodes().ElementAt(_ICountry.GetCountryNames().IndexOf(country));
            }
            catch
            {
                return null;
            }

            string apikey = ConfigurationManager.AppSettings["apikey"].ToString();

            url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "," + countryCode + "&units=metric&APPID=" + apikey; ;

            using (WebClient client = new WebClient())
            {
                try
                {
                    response = client.DownloadString(url);
                    dynamic joResponse = JsonConvert.DeserializeObject(response);
                    WeatherInfo weather = new WeatherInfo
                    {
                        location = new Location
                        {
                            country = country,
                            city = city,
                        },
                        temp = new Temperature
                        {
                            value = joResponse.main.temp,
                            format = "Celsius",
                        },
                        humidity = new Humidity
                        {
                            value = joResponse.main.humidity,
                        },
                    };
                    return weather;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}