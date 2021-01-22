using AspNetCore5FromClaimsDataBinding.FromClaimsDataBinding;
using AspNetCore5FromClaimsDataBinding.Models;
using AspNetCore5FromClaimsDataBinding.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5FromClaimsDataBinding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _wartherForecastService;

        public WeatherForecastController(IWeatherForecastService wartherForecastService)
        {
            _wartherForecastService = wartherForecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromClaims] string zip)
        {
            return _wartherForecastService.GetWeatherForecastForZip(zip);
        }
    }
}
