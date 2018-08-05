using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FindFlightMatch
    {
        [DataMember(Name="num_segments")]
        public int NumberOfSegments { get; set; }

        [DataMember(Name="segments")]
        public IEnumerable<FlightInfoStatusStruct> Segments { get; set; }
    }
}