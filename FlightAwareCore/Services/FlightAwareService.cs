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
                                                                FlightStatus type = FlightStatus.All,
                                                                int howMany = 15,
                                                                int offset = 0)
        {
            return await client.HttpRequest<AirportBoardsResponse>("AirportBoards", new { 
                airport_code = airportCode,
                include_ex_data = includeExData,
                filter = filter,
                type = Enum.GetName(typeof(FlightStatus), type).ToLower(),
                howMany = howMany,
                offset = offset
            });
        }

        public async Task AirportDelays()
        {
            throw new NotImplementedException("Not available for Starter Plan");
        }

        ///<summary>
        /// Information about an airport.
        ///</summary>
        ///<param name="airportCode">ICAO Airport Id</param>
        public async Task<AirportInfoResponse> AirportInfo(string airportCode)
        {
            return await client.HttpRequest<AirportInfoResponse>("AirportInfo", new { airport_code = airportCode });
        }

        ///<summary>
        /// Check whether or not an aircraft is blocked from public tracking
        ///</summary>
        ///<param name="tailNumber">Tail Number</param>
        public async Task<BlockIdentCheckResponse> BlockIdentCheck(string tailNumber)
        {
            return await client.HttpRequest<BlockIdentCheckResponse>("BlockIdentCheck", new { ident = tailNumber });
        }

        ///<summary>
        /// The number of aircraft schedule, en route, or departing a given aiport. 
        /// Scheduled arrivals are non-airborne flights that are scheduled to fly to the airport in question.
        ///</summary>
        ///<param name="airportCode">ICAO Airport Id</param>
        public async Task<CountAirportOperationsResponse> CountAirportOperations(string airportCode)
        {
            return await client.HttpRequest<CountAirportOperationsResponse>("CountAirportOperations", new { airport_code = airportCode });
        }

        ///<summary>
        /// List of airlines and how many flights each currently has enroute.
        ///</summary>
        public async Task<CountAllEnrouteAirlineOperationsResponse> CountAllEnrouteAirlineOperations()
        {
            return await client.HttpRequest<CountAllEnrouteAirlineOperationsResponse>("CountAllEnrouteAirlineOperations");
        }

        ///<summary>
        /// A "cracked" list of noteworthy navigation points along the planned flight route. 
        /// The list represents the originally planned route of travel, which may differ slightly from the actual flight path flown.
        /// Not all flight routes can be successfully decoded by this function, particularly if the flight is not entirely within the continental U.S. airspace, since this function only has access to navaids within that area.
        ///</summary>
        ///<param name="flightId">FlightAware Flight Id</param>
        public async Task<DecodeFlightRouteResponse> DecodeFlightRoute(string flightId)
        {
            return await client.HttpRequest<DecodeFlightRouteResponse>("DecodeFlightRoute", new { faFlightID = flightId });
        }

        ///<summary>
        /// A "cracked" list of noteworthy navigation points along the planned flight route. 
        /// The list represents the originally planned route of travel, which may differ slightly from the actual flight path flown.
        /// Not all flight routes can be successfully decoded by this function, particularly if the flight is not entirely within the continental U.S. airspace, since this function only has access to navaids within that area.
        ///</summary>
        ///<param name="originAirportCode">Origin airport code</param>
        ///<param name="route">Space separated list of intersections and/or VORs along the route (e.g. WYLSN MONNT KLJOY MAJKK REDDN4)</param>
        ///<param name="destinationAirportCode">Destination airport code</param>
        public async Task<DecodeRouteResponse> DecodeRoute(string originAirportCode, string route, string destinationAirportCode)
        {
            return await client.HttpRequest<DecodeRouteResponse>("DecodeRoute", new 
            { 
                origin = originAirportCode,
                route = route, 
                destination = destinationAirportCode
            });
        }

        public async Task<FindFlightResponse> FindFlight(string origin,
                                    string destination,
                                    bool includeExData = false, 
                                    string filter = null,
                                    FlightType type = FlightType.Auto,
                                    int howMany = 15,
                                    int offset = 0)
        {
            return await client.HttpRequest<FindFlightResponse>("FindFlight", new {
                origin = origin,
                destination = destination,
                include_ex_data = includeExData,
                type = Enum.GetName(typeof(FlightType), type).ToLower(),
                filter = filter,
                howMany = howMany,
                offset = offset
            });
        }

        public async Task<FlightCancellationStatisticsResponse> FlightCancellationStatistics(string timePeriod,
                                                        AggregationCriteria typeMatching,
                                                        string identFilter = null,
                                                        int howMany = 15,
                                                        int offset = 0)
        {
            return await client.HttpRequest<FlightCancellationStatisticsResponse>("FlightCancellationStatistics", new {
                time_period = timePeriod,
                type_matching = Enum.GetName(typeof(AggregationCriteria), typeMatching).ToLower(),
                ident_filter = identFilter,
                howMany = howMany,
                offset = offset
            });
        }

        ///<summary>
        ///information about flights for a specific tail number (e.g., N12345), or an ident (typically an ICAO airline with flight number, e.g., SWA2558), or a FlightAware-assigned unique flight identifier (e.g. faFlightID returned by another FlightXML function).	
        /// When a tail number or ident is specified and multiple flights are available, the results will be returned from newest to oldest. The oldest flights searched by this function are about 2 weeks in the past.
        /// Codeshares and alternate idents are automatically searched.	
        /// When a FlightAware-assigned unique flight identifier is supplied, at most a single result will be returned.
        /// Times are provided in a nested data structure that contains the representation in several different formats, including UTC integer seconds since 1970 (UNIX epoch time), and integer seconds since 1970 relative to the local (airport) timezone.
        /// The estimated time enroute (filed_ete) is given in seconds.
        ///</summary>
        ///<param name="ident">Requested tail number, ident, atc_ident, or faFlightID</param>
        ///<param name="includeExData"> Include extended flight information. Default: false</param>
        ///<param name="filter">Specify "ga" to show only general aviation traffic, "airline" to only show airline traffic. If null/void then all types are returned. You can also limit results to a particular airline by specifying "airline:airlineCode" where the airlineCode is the ICAO identifier for that airline. Default: null</param>
        ///<param name="howMany">Number of flights to fetch. Default: 15</param>
        ///<param name="offset">Offset for query. Default: 0</param>
        public async Task<FlightInfoStatusResponse> FlightInfoStatus(string ident, 
                                                                    bool includeExData = false, 
                                                                    string filter = null,
                                                                    int howMany = 15,
                                                                    int offset = 0)
        {
            return await client.HttpRequest<FlightInfoStatusResponse>("FlightInfoStatus", new 
            {
                ident = ident,
                include_ex_data = includeExData,
                filter = filter,
                howMany = howMany,
                offset = offset
            });
        }

        public async Task<FlightTrackResponse> GetFlightTrack(string ident, bool includePositionEstimates = false)
        {
            return await client.HttpRequest<FlightTrackResponse>("GetFlightTrack", new { ident = ident, include_position_estimates = includePositionEstimates });
        }

        public async Task LatLongsToDistance()
        {
            throw new NotImplementedException();
        }

        public async Task LatLongsToHeading()
        {
            throw new NotImplementedException();
        }

        public async Task NearbyAirports()
        {
            throw new NotImplementedException();
        }

        public async Task RoutesBetweenAirports()
        {
            throw new NotImplementedException();
        }

        ///<summary>
        /// Information about the owner of an aircraft, given a flight number or N-number.
        /// Codeshares and alternate idents are automatically searched.
        ///</summary>
        ///<param name="ident">Flight number or N-number.</param>
        public async Task<TailOwnerResponse> TailOwner(string ident)
        {
            
            return await client.HttpRequest<TailOwnerResponse>("TailOwner", new { ident = ident });
        }

        public async Task WeatherConditions()
        {
            throw new NotImplementedException();
        }

        public async Task WeatherForecast()
        {
            throw new NotImplementedException();
        }

        ///<summary>
        /// Information about a five-digit zipcode. Of particular importance is latitude and longitude.
        ///</summary>
        ///<param name="zipCode">A five-digit U.S.sealed Postal Service zipcode.</param>
        public async Task<ZipCodeInfoResponse> ZipcodeInfo(string zipCode)
        {
            return await client.HttpRequest<ZipCodeInfoResponse>("ZipcodeInfo", new { zipcode = zipCode });
        }
    }
}
