using AspNetCore5FromClaimsDataBinding.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCore5FromClaimsDataBinding.Tests.Utils
{
    class FakeWebApplicationFactory
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public Mock<IWeatherForecastService> WeatherForecastService { get; private set; } = new Mock<IWeatherForecastService>();

        public FakeWebApplicationFactory()
        {
            _factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.PostConfigure(JwtBearerDefaults.AuthenticationScheme, (Action<JwtBearerOptions>)(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            IssuerSigningKey = FakeJwtManager.SecurityKey,
                            ValidIssuer = FakeJwtManager.Issuer,
                            ValidateAudience = false,
                        };
                    }));
                });

                builder.ConfigureServices(services =>
                {
                    // Replace with mocks
                    services.Remove(services.SingleOrDefault(d => d.ServiceType == typeof(IWeatherForecastService)));
                    services.AddSingleton<IWeatherForecastService>(this.WeatherForecastService.Object);
                });
            });
        }

        public HttpClient CreateClientWithTestAuth()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            return client;
        }

    }
}
