using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class ZipCodeInfoStruct
    {
        [DataMember(Name="city")]
        public string City { get; set; }

        [DataMember(Name="county")]
        public string County { get; set; }

        [DataMember(Name="latitude")]
        public float Latitude { get; set; }

        [DataMember(Name="longitude")]
        public float Longitude { get; set; }

        [DataMember(Name="state")]
        public string State { get; set; }
    }
}