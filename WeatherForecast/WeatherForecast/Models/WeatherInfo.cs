using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class WeatherInfo
    {
        //public string apiResponse { get; set; }

        public Location location { get; set; }

        public Temperature temp { get; set; }
        public Humidity humidity { get; set; }
    }
}