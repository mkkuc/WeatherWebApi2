using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        private const string apikey = "8832d4538967178c113cee0a8a850cda";
        private string url;

        [Route("{city}/{country}")]
        public IHttpActionResult Get(string country, string city)
        {
            string response;
            string countryCode;
            Country Icountry = new Country();
            //List<string> _countryCodes = Icountry.GetCountryCodes();
           // List<string> _countryNames = Icountry.GetCountryNames();
            try
            {
                countryCode = Icountry.GetCountryCodes().ElementAt(Icountry.GetCountryNames().IndexOf(country));
            }
            catch
            {
                return NotFound();
            }

            url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "," + countryCode + "&units=metric&APPID=" + apikey; ;

            using (WebClient client = new WebClient())
            {
                try
                {
                    response = client.DownloadString(url);
                    dynamic joResponse = JsonConvert.DeserializeObject(response);

                    //string value = "Temperatura: " + joResponse.main.temp + ",\n" + "Wilgotność: " + joResponse.main.humidity;
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
                    return Ok(weather);
                }
                catch
                {
                    return NotFound();
                }
            }
        }

 
    }

}
