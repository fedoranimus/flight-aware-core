using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class AircraftTypeResponse {
        [DataMember(Name="AircraftTypeResult")]
        public AircraftTypeStruct AircraftType { get; set; }
    }
}