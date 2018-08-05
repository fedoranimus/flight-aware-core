using System.Runtime.Serialization;

namespace FlightAware.Models
{
    public class AirportDisplayStruct 
    {
        [DataMember(Name="code")]
        public string Code { get; set; }
        [DataMember(Name="city")]
        public string City { get; set; }
        [DataMember(Name="alternate_ident")]
        public string AlternateIdent { get; set; }
        [DataMember(Name="airport_name")]
        public string AirportName { get; set; }
    }
}