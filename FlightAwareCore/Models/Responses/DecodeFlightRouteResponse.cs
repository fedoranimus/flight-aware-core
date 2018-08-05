using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class DecodeFlightRouteResponse
    {
        [DataMember(Name="DecodeFlightRouteResult")]
        public DecodeFlightRouteResult Result { get; set; }
    }

    [DataContract]
    public class DecodeFlightRouteResult
    {
        [DataMember(Name="data")]
        public IEnumerable<FlightRouteStruct> Data { get; set; }
        
        [DataMember(Name="route_distance")]
        public string RouteDistance { get; set; }
    }
}