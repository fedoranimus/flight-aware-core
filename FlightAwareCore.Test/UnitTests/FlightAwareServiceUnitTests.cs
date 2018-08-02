using System;
using Xunit;
using FlightAware.Services;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Moq;

namespace FlightAwareCore.Test
{
    public class FlightAwareServiceUnitTests
    {
        // readonly HttpResponseMessage _mockAircraftTypeResponse = new HttpResponseMessage
        // {
        //     Content = new StringContent(File.ReadAllText($"{AppContext.BaseDirectory}/Data/aircraft_type.json"))
        // };
        [Fact]
        public void Constructor_With_Non_Empty_Parameters()
        {
            var flightAwareService = new FlightAwareService("username", "apikey");
            Assert.NotNull(flightAwareService);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Exception_Thrown_For_Missing_Api_Key(string value)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var flightAwareService = new FlightAwareService("username", value);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Exception_Thrown_For_Missing_Username(string value)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var flightAwareService = new FlightAwareService(value, "apiKey");
            });
        }
    }
}
