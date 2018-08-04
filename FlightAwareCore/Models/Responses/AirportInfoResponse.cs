using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class AirportInfoResponse
    {
        [DataMember(Name="AirportInfoResult")]
        public AirportStruct Airport { get; set; }
    }
}