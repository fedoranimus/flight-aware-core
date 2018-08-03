using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class AirportStruct
    {
        [DataMember(Name="airport_code")]
        public string AirportCode { get; set; }
        public string Name { get; set; }
        public float Elevation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Timezone { get; set; }
        [DataMember(Name="country_code")]
        public string CountryCode { get; set; }
        [DataMember(Name="wiki_url")]
        public string WikiUrl { get; set; }
        [DataMember(Name="alternate_ident")]
        public string AlternateIdent { get; set; }
    }
}