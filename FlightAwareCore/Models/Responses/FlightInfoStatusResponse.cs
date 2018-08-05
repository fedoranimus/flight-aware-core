using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightInfoStatusResponse
    {
        [DataMember(Name="FlightInfoStatusResult")]
        public FlightInfoStatusResult Results { get; set; }
    }

    [DataContract]
    public class FlightInfoStatusResult
    {
        [DataMember(Name="next_offset")]
        public int NextOffset { get; set; }

        [DataMember(Name="flights")]
        public IEnumerable<FlightInfoStatusStruct> Flights { get; set; }
    }
}