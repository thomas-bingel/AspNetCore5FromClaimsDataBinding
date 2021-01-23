# Asp Net Core 5 FromClaims DataBinding like [FromPath]
ASP.NET Core example on how to implement FromClaims attribute to easily access claims in a controller.

As an example I used the WeatherForecast template and added all necessary classes to the project.  
```C# 
[HttpGet]
public IEnumerable<WeatherForecast> Get([FromClaims] string zip)
{
    return _wartherForecastService.GetWeatherForecastForZip(zip);
}
```

You need 4 classes to get this working: 
- FromClaimsAttribute.cs
- FromClaimsBindingSource.cs
- FromClaimsDataBinderProvider.cs
- FromClaimsModelBinder.cs

The last thing is to add the ModelBinderProvider:
```c#
services.AddControllers(config => {
    config.ModelBinderProviders.Insert(0, new FromClaimsDataBinderProvider());
});
```

All other classes / services are for testing purposes only.

Have Fun ;-)

