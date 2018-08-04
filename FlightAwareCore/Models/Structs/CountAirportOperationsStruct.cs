using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class CountAirportOperationsStruct
    {
        [DataMember(Name="departed")]
        public int Departed { get; set; }

        [DataMember(Name="enroute")]
        public int EnRoute { get; set; }

        [DataMember(Name="scheduled_arrivals")]
        public int ScheduledArrivals { get; set; }

        [DataMember(Name="scheduled_departures")]
        public int ScheduledDepartures { get; set; }
    }
}