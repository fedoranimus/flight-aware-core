using System;
using System.Threading.Tasks;
using FlightAware.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Xunit;

namespace FlightAwareCore.Test
{
    public class FlightAwareServiceIntegrationTests : IDisposable
    {
        readonly string _apiEnvVar = "FAkey";
        readonly string _usernameEnvVar = "FAuser";
        private FlightAwareService _flightAwareService;
        public FlightAwareServiceIntegrationTests()
        {
            var config = new ConfigurationBuilder()
                                .AddEnvironmentVariables()
                                .Build();
                                
            var apiKey = config.GetSection(_apiEnvVar).Value;
            Assert.False(string.IsNullOrEmpty(apiKey), $"You must set the environment variable {_apiEnvVar}");
            var userNameKey = config.GetSection(_usernameEnvVar).Value;
            Assert.False(string.IsNullOrEmpty(userNameKey), $"You must set the environment variable {_usernameEnvVar}");
            _flightAwareService = new FlightAwareService(userNameKey, apiKey);
        }

        [Theory]
        [InlineData("GALX")]
        public async Task AircraftType_Should_Return_Response(string acType)
        {
            var response = await _flightAwareService.AircraftType(acType);

            Assert.NotNull(response.AircraftType);
            Assert.Equal("twin-jet", response.AircraftType.Description);
            Assert.Equal(2, response.AircraftType.EngineCount);
            Assert.Equal("jet", response.AircraftType.EngineType);
            Assert.Equal("IAI", response.AircraftType.Manufacturer);
            Assert.Equal("Gulfstream G200", response.AircraftType.Type);
        }

        public void Dispose()
        {
            
            _flightAwareService = null;
        }
    }
}
