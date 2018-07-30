using System;
using System.Threading.Tasks;

namespace FlightAware.Services
{
    /// <summary>
    /// Wrapper class for interacting with the Flight Aware API
    /// </summary>
    public class FlightAwareService
    {
        readonly string apiKey;
        readonly string username;
        readonly IHttpClient httpClient;

        public FlightAwareService(string username, string apiKey, IHttpClient httpClient = null)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"{nameof(username)} cannot be empty.");
            }

            if(string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException($"{nameof(apiKey)} cannot be empty.");
            }

            this.username = username;
            this.apiKey = apiKey;
            this.httpClient = httpClient ?? new ZipHttpClient("http://flightxml.flightaware.com/json/FlightXML3");
        }

        public async Task AircraftType()
        {

        }

        public async Task AirlineFlightSchedules()
        {

        }

        public async Task AirlineInfo()
        {

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
