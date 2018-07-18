using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    public interface ICountry
    {
        List<string> GetCountryCodes();
        List<string> GetCountryNames();
    }
}
