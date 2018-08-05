using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightTrackResponse
    {
        [DataMember(Name="GetFlightTrackResult")]
        public GetFlightTrackResult Results { get; set; }
    }

    [DataContract]
    public class GetFlightTrackResult
    {
        [DataMember(Name="tracks")]
        public IEnumerable<TrackStruct> Tracks { get; set; }
    }
}