using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightRouteStruct
    {
        [DataMember(Name="distance_from_origin")]
        public float? DistanceFromOrigin { get; set; }

        [DataMember(Name="distance_this_leg")]
        public float? DistanceFromPreviousPoint { get; set; }

        [DataMember(Name="distance_to_destination")]
        public float? DistanceToDestination { get; set; }

        [DataMember(Name="latitude")]
        public float? Latitude { get; set; }

        [DataMember(Name="longitude")]
        public float? Longitude { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="outbound_course")]
        public float? OutboundCourse { get; set; }

        [DataMember(Name="type")]
        public string Type { get; set; }
    }
}