using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class AirlineInfoStruct
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        
        [DataMember(Name="shortname")]
        public string ShortName { get; set; }

        [DataMember(Name="callsign")]
        public string CallSign { get; set; }

        [DataMember(Name="location")]
        public string Location { get; set; }

        [DataMember(Name="country")]
        public string Country { get; set; }

        [DataMember(Name="phone")]
        public string Phone { get; set; }
    
        [DataMember(Name="url")]
        public string Url { get; set; }

        [DataMember(Name="wiki_url")]
        public string WikiUrl { get; set; }

        [DataMember(Name="airbourne")]
        public int? Airbourne { get; set; }

        [DataMember(Name="flights_last_24_hours")]
        public int? FlightLast24Hours { get; set; }
    }
}