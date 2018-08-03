using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class AirportBoardsResponse
    {
        [DataMember(Name="airport")]
        public string Airport { get; set; }

        [DataMember(Name="airport_info")]
        public AirportStruct AirportInfo { get; set; }

        [DataMember(Name="arrivals")]
        public TrackAirportStruct Arrivals { get; set; }

        [DataMember(Name="departures")]
        public TrackAirportStruct Departures { get; set; }

        [DataMember(Name="enroute")]
        public TrackAirportStruct EnRoute { get; set; }

        [DataMember(Name="scheduled")]
        public TrackAirportStruct Scheduled { get; set; }
    }
}