using System;
using System.Threading.Tasks;
using FlightAware.Models;
using FlightAware.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Xunit;

namespace FlightAwareCore.Test
{
    public class FlightAwareServiceIntegrationTests : IDisposable
    {
        readonly string _apiEnvVar = "FaKey";
        readonly string _usernameEnvVar = "FaUser";
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
        public async Task AircraftType_Should_Return_Response(string aircraftType)
        {
            var response = await _flightAwareService.AircraftType(aircraftType);

            Assert.NotNull(response.AircraftType);
            Assert.Equal("twin-jet", response.AircraftType.Description);
            Assert.Equal(2, response.AircraftType.EngineCount);
            Assert.Equal("jet", response.AircraftType.EngineType);
            Assert.Equal("IAI", response.AircraftType.Manufacturer);
            Assert.Equal("Gulfstream G200", response.AircraftType.Type);
        }

        [Theory]
        [InlineData("JBU")]
        public async Task AirlineInfo_Should_Return_Response(string airlineCode)
        {
            var response = await _flightAwareService.AirlineInfo(airlineCode);

            Assert.NotNull(response.AirlineInfo);
            Assert.Equal("JetBlue Airways", response.AirlineInfo.Name);
            Assert.Equal("JetBlue", response.AirlineInfo.CallSign);
        }

        [Theory]
        [InlineData("KBOS")]
        public async Task AirportBoards_Should_Return_Response(string airportCode)
        {
            var response = await _flightAwareService.AirportBoards(airportCode);

            Assert.NotNull(response);
            Assert.Equal(airportCode, response.Results.Airport);
            Assert.NotNull(response.Results.AirportInfo);
            Assert.NotNull(response.Results.Arrivals);
            Assert.NotNull(response.Results.Departures);
            Assert.NotNull(response.Results.EnRoute);
            Assert.NotNull(response.Results.Scheduled);
        }

        [Theory]
        [InlineData("KBOS")]
        public async Task AirportInfo_Should_Return_Response(string airportCode)
        {
            var response = await _flightAwareService.AirportInfo(airportCode);
            
            Assert.NotNull(response);
            Assert.NotNull(response.Airport);
        }

        [Theory]
        [InlineData("A7-ALN")]
        public async Task BlockIdentCheck_Should_Return_Response(string tailNumber)
        {
            var response = await _flightAwareService.BlockIdentCheck(tailNumber);

            Assert.NotNull(response);
            Assert.IsType<bool>(response.IsBlocked);
        }

        [Theory]
        [InlineData("KBOS")]
        public async Task CountAirportOperations_Should_Return_Response(string airportCode)
        {
            var response = await _flightAwareService.CountAirportOperations(airportCode);

            Assert.NotNull(response);
            Assert.NotNull(response.Operations);
            Assert.IsType<int>(response.Operations.Departed);
            Assert.IsType<int>(response.Operations.EnRoute);
            Assert.IsType<int>(response.Operations.ScheduledArrivals);
            Assert.IsType<int>(response.Operations.ScheduledDepartures);
        }

        [Fact]
        public async Task CountAllEnrouteAirlineOperations_Should_Return_Response()
        {
            var response = await _flightAwareService.CountAllEnrouteAirlineOperations();

            Assert.NotNull(response);
            Assert.NotNull(response.AirlineOperationsCollection);
        }

        [Theory]
        [InlineData("QTR743-1533272400-schedule-0000")]
        public async Task DecodeFlightRoute_Should_Return_Response(string flightId)
        {
            var response = await _flightAwareService.DecodeFlightRoute(flightId);

            Assert.NotNull(response);
            Assert.NotNull(response.Result.RouteDistance);
            Assert.NotNull(response.Result.Data);
        }

        [Theory]
        [InlineData("BOS", "WYLSN MONNT KLJOY MAJKK REDDN4", "MSP")]
        public async Task DecodeRoute_Should_Return_Response(string origin, string route, string destination)
        {
            var response = await _flightAwareService.DecodeRoute(origin, route, destination);

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
        }

        [Theory]
        [InlineData("BOS", "MSP")]
        public async Task FindFlight_Should_Return_Response(string origin, string destination)
        {
            var response = await _flightAwareService.FindFlight(origin, destination);

            Assert.NotNull(response);
            Assert.NotNull(response.Results.Flights);
            Assert.IsType<int>(response.Results.NextOffset);
            Assert.IsType<int>(response.Results.NumberOfFlights);
        }

        [Theory]
        [InlineData("today", AggregationCriteria.Airline)]
        [InlineData("twoDaysAgo", AggregationCriteria.Destination)]
        public async Task FlightCancellationStatistics_Should_Return_Response(string timePeriod, AggregationCriteria typeMatching)
        {
            var response = await _flightAwareService.FlightCancellationStatistics(timePeriod, typeMatching);

            Assert.NotNull(response);
            Assert.NotNull(response.Results);
        }

        [Theory]
        [InlineData("N12345")]
        [InlineData("SWA2558")]
        public async Task FlightInfoStatus_Should_Return_Response(string ident)
        {
            var response = await _flightAwareService.FlightInfoStatus(ident);

            Assert.NotNull(response);
            Assert.NotNull(response.Results.Flights);
            Assert.IsType<int>(response.Results.NextOffset);
        }

        [Theory]
        [InlineData("SWA35-1491974780-airline-0046")]
        [InlineData("SWA35@1492200000")]
        public async Task GetFlightTrack_Should_Return_Response(string ident)
        {
            var response = await _flightAwareService.GetFlightTrack(ident);

            Assert.NotNull(response);
            Assert.NotNull(response.Results.Tracks);
        }

        [Theory]
        [InlineData("SWA2558")]
        [InlineData("N12345")]
        public async Task TailOwner_Should_Return_Response(string flightNumber)
        {
            var response = await _flightAwareService.TailOwner(flightNumber);

            Assert.NotNull(response);
            Assert.NotNull(response.TailOwner);
        }

        [Theory]
        [InlineData("03062")]
        public async Task ZipcodeInfo_Should_Return_Response(string zipCode)
        {
            var response = await _flightAwareService.ZipcodeInfo(zipCode);

            Assert.NotNull(response);
            Assert.NotNull(response.ZipCodeInfo);
        }

        public void Dispose()
        {
            _flightAwareService = null;
        }
    }
}
