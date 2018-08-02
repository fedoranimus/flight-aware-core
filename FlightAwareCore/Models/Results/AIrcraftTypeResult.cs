using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract(Name="AircraftResult")]
    public class AircraftTypeResult
    {
        [DataMember(Name="manufacturer")]
        public string Manufacturer { get; set; }
        [DataMember(Name="type")]
        public string Type { get; set; }
        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="engine_count")]
        public int EngineCount { get; set; }

        [DataMember(Name="engine_type")]
        public string EngineType { get; set; }
    }
}