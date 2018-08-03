using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FlightAware.Models;
using Flurl;
using Newtonsoft.Json;

namespace FlightAware.Services
{
    /// <summary>
    /// Wrapper class for interacting with the Flight Aware API
    /// </summary>
    public class FlightAwareService
    {
        private readonly ZipHttpClient client;

        public FlightAwareService(string username, string apiKey)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"{nameof(username)} cannot be empty.");
            }

            if(string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException($"{nameof(apiKey)} cannot be empty.");
            }
            client = new ZipHttpClient("https://flightxml.flightaware.com/json/FlightXML3", username, apiKey);
        }

        public async Task<AircraftTypeResponse> AircraftType(string aircraftType)
        {
            return await client.HttpRequest<AircraftTypeResponse>("AircraftType", new { type = aircraftType });
        }

        public async Task AirlineFlightSchedules()
        {

        }

        public async Task<AirlineInfoResponse> AirlineInfo(string airlineCode)
        {
            return await client.HttpRequest<AirlineInfoResponse>("AirlineInfo", new { airline_code = airlineCode });
        }

        public async Task AirportBoards()
        {

        }

        public async Task AirportDelays()
        {

        }

        public async Task AirportInfo()
        {

        }

        public async Task BlockIdentCheck()
        {

        }

        public async Task CountAirportOperations()
        {

        }

        public async Task CountAllEnrouteAirlineOperations()
        {

        }

        public async Task DecodeFlightRoute()
        {

        }

        public async Task FindFlight()
        {

        }

        public async Task FlightCancellationStatistics()
        {

        }

        public async Task FlightInfoStatus()
        {

        }

        public async Task GetFlightTrack()
        {

        }

        public async Task LatLongsToDistance()
        {

        }

        public async Task LatLongsToHeading()
        {

        }

        public async Task NearbyAirports()
        {

        }

        public async Task RoutesBetweenAirports()
        {

        }

        public async Task TailOwner()
        {

        }

        public async Task WeatherConditions()
        {

        }

        public async Task WeatherForecast()
        {

        }

        public async Task ZipcodeInfo()
        {

        }
    }
}
