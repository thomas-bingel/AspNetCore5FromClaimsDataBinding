using AspNetCore5FromClaimsDataBinding.Tests.Utils;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Xunit;

namespace AspNetCore5FromClaimsDataBinding.Tests
{
    public class FromClaimsAttributeIntegreationTest
    {
        private readonly FakeWebApplicationFactory _factory;
        private readonly HttpClient _client;
        private readonly string _rootUrl = "/WeatherForecast";

        public FromClaimsAttributeIntegreationTest()
        {
            _factory = new FakeWebApplicationFactory();
            _client = _factory.CreateClientWithTestAuth();
        }


        [Fact]
        public void CallWithValidAccessToken_ShouldReturnSuccess()
        {
            // Arrange
            var zip = "12345";
            var claims = new List<Claim>() { new Claim("zip", zip) };

            // Act
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", FakeJwtManager.GenerateJwtToken(claims));
            var response = _client.GetAsync(_rootUrl).GetAwaiter().GetResult();

            // Assert
            response.StatusCode
                   .Should().Be(System.Net.HttpStatusCode.OK);
            _factory.WeatherForecastService
                .Verify(p => p.GetWeatherForecastForZip(It.Is<string>(arg => zip == arg)), Times.Once);
        }
    }
}
