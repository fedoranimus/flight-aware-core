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
    public partial class FlightAwareService
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

        ///<summary>
        /// Information about an aircraft type, comprising the manufacturer, type, and description
        ///</summary>
        ///<param name="aircraftType">Aircraft Type Id</param>
        public async Task<AircraftTypeResponse> AircraftType(string aircraftType)
        {
            return await client.HttpRequest<AircraftTypeResponse>("AircraftType", new { type = aircraftType });
        }

        ///<summary>
        /// Flight schedules that have been published by airlines.
        /// These schedules are avilable for the recent past as well as up to one year into the future.
        /// Flights performed by airline codeshares are also returned by default in these results but can be excluded. 
        /// If available the FlightAware flight id will be returned.
        ///</summary>
        public async Task AirlineFlightSchedules()
        {
            throw new NotImplementedException("Not available for Starter and Bronze Plans");
        }

        ///<summary>
        /// Information about a commercial airline/carrier given an ICAO airline code
        ///</summary>
        ///<param name="airlineCode">ICAO Airline Id</param>
        public async Task<AirlineInfoResponse> AirlineInfo(string airlineCode)
        {
            return await client.HttpRequest<AirlineInfoResponse>("AirlineInfo", new { airline_code = airlineCode });
        }


        ///<summary>
        /// Flights scheduled, departing, enroute, and arriving at a specified airport
        ///</summary>
        ///<param name="airportCode">ICAO Airport Id</param>
        ///<param name="includeExData"> Include extended flight information. Default: false</param>
        ///<param name="filter">Specify "ga" to show only general aviation traffic, "airline" to only show airline traffic. If null/void then all types are returned. You can also limit results to a particular airline by specifying "airline:airlineCode" where the airlineCode is the ICAO identifier for that airline. Default: null</param>
        ///<param name="type">Type of flights. Default: all</param>
        ///<param name="howMany">Number of flights to fetch. Default: 15</param>
        ///<param name="offset">Offset for query. Default: 0</param>
        public async Task<AirportBoardsResponse> AirportBoards(string airportCode, 
                                                                bool includeExData = false, 
                                                                string filter = null,
                                                                FlightType type = FlightType.All,
                                                                int howMany = 15,
                                                                int offset = 0)
        {
            return await client.HttpRequest<AirportBoardsResponse>("AirportBoards", new { 
                airport_code = airportCode,
                include_ex_data = includeExData,
                filter = filter,
                type = type.ToString(),
                howMany = howMany,
                offset = offset
            });
        }

        public async Task AirportDelays()
        {
            throw new NotImplementedException("Not available for Starter Plan");
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

        ///<summary>
        /// Information about a five-digit zipcode. Of particular importance is latitude and longitude.
        ///</summary>
        ///<param name="zipCode">A five-digit U.S.sealed Postal Service zipcode.</param>
        public async Task ZipcodeInfo(string zipCode)
        {

        }
    }
}
