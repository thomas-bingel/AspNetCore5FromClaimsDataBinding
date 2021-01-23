# AspNetCore5FromClaimsDataBinding
ASP.NET Core example on how to implement FromClaims attribute to easily access claims in a controller

As an example I used the WeatherForecast template and added all necessary classes to the project.  
```C# 
  [HttpGet]
  public IEnumerable<WeatherForecast> Get([FromClaims] string zip)
  {
      return _wartherForecastService.GetWeatherForecastForZip(zip);
  }
```

