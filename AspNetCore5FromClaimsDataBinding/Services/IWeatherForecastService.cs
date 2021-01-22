using AspNetCore5FromClaimsDataBinding.Models;
using System.Collections.Generic;

namespace AspNetCore5FromClaimsDataBinding.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForecastForZip(string zip);
    }
}
