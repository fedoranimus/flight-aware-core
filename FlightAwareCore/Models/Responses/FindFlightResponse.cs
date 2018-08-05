using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FindFlightResponse
    {
        [DataMember(Name="FindFlightResult")]
        public FindFlightResult Results { get; set; }
    }

    [DataContract]
    public class FindFlightResult
    {
        [DataMember(Name="next_offset")]
        public int NextOffset { get; set; }

        [DataMember(Name="num_flights")]
        public int NumberOfFlights { get; set; }

        [DataMember(Name="flights")]
        public IEnumerable<FindFlightMatch> Flights { get; set; }
    }
}