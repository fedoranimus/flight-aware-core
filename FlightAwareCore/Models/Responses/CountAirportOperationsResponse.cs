using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class CountAirportOperationsResponse
    {
        [DataMember(Name="CountAirportOperationsResult")]
        public CountAirportOperationsResponse Operations { get; set; }
    }
}