using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightInfoStatusResponse
    {
        [DataMember(Name="next_offset")]
        public int NextOffset { get; set; }

        [DataMember(Name="flights")]
        public List<FlightInfoStatusStruct> Flights { get; set; }
    }
}