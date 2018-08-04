using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class CountAllEnrouteAirlineOperationsResponse
    {
        [DataMember(Name="CountAllEnrouteAirlineOperationsResult")]
        public ArrayOfCountAirlineOperationsStruct AirlineOperationsCollection { get; set;}
    }

    public class ArrayOfCountAirlineOperationsStruct
    {
        [DataMember(Name="data")]
        public List<CountAirlineOperationsStruct> AirlineOperations { get; set; }
    }
}