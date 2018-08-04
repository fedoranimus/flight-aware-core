using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class DecodeRouteResponse
    {
        [DataMember(Name="data")]
        public List<FlightRouteStruct> Data { get; set; }
        
        [DataMember(Name="route_distance")]
        public string RouteDistance { get; set; }
    }
}