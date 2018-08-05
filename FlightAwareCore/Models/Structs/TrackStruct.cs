using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class TrackStruct
    {
        [DataMember(Name="altitude")]
        public int Altitude { get; set; }

        [DataMember(Name="altitude_change")]
        public string altitudeChange { get; set; }

        [DataMember(Name="altitude_feet")]
        public int? AltitudeFeet { get; set; }

        [DataMember(Name="altitude_status")]
        public string AltitudeStatus { get; set; }

        [DataMember(Name="groundspeed")]
        public int GroundSpeed { get; set; }

        [DataMember(Name="heading")]
        public int? Heading { get; set; }

        [DataMember(Name="latitude")]
        public float Latitude { get; set; }

        [DataMember(Name="longitude")]
        public float Longitude { get; set; }

        [DataMember(Name="timestamp")]
        public int Timestamp { get; set; }

        [DataMember(Name="update_type")]
        public string UpdateType { get; set; }
    }
}