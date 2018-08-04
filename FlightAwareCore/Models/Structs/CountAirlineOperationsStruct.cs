using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class CountAirlineOperationsStruct
    {
        [DataMember(Name="enroute")]
        public int EnRoute { get; set; }

        [DataMember(Name="icao")]
        public string ICAO { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}