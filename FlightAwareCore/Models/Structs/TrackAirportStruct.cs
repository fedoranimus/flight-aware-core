using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class TrackAirportStruct
    {
        [DataMember(Name="num_flights")]
        public int NumFlights { get; set; }
        [DataMember(Name="next_offset")]
        public int NextOffset { get; set; }
        public List<FlightInfoStatusStruct> Flights { get; set; }
    }
}