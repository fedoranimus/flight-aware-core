using System;
using FlightAware.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Xunit;

namespace FlightAwareCore.Test
{
    public class FlightAwareServiceIntegrationTests : IDisposable
    {
        readonly string _apiEnvVar = "";
        readonly string _usernameEnvVar = "";
        private FlightAwareService _flightAwareService;
        public FlightAwareServiceIntegrationTests()
        {
            var configBuilder = new ConfigurationBuilder().AddEnvironmentVariables();
            var config = configBuilder.Build();
            var apiKey = config.GetSection(_apiEnvVar).Value.ToString();
            Assert.False(string.IsNullOrWhiteSpace(apiKey), $"You must set the environment variable {_apiEnvVar}");
            var userNameKey = config.GetSection(_usernameEnvVar).Value.ToString();
            Assert.False(string.IsNullOrWhiteSpace(userNameKey), $"You must set the environment variable {_usernameEnvVar}");
            _flightAwareService = new FlightAwareService(userNameKey, apiKey);
        }

        public void Dispose()
        {
            
            _flightAwareService = null;
        }
    }
}
