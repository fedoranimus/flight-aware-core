using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightTrackResponse
    {
        [DataMember(Name="tracks")]
        public IEnumerable<TrackStruct> Tracks { get; set; }
    }
}