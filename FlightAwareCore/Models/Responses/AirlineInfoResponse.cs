using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class AirlineInfoResponse 
    {
        [DataMember(Name="AirlineInfoResult")]
        public AirlineInfoStruct AirlineInfo { get; set; }
    }
}