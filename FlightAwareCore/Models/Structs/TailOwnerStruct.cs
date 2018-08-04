using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class TailOwnerStruct
    {
        [DataMember(Name="location")]
        public string Location { get; set; }

        [DataMember(Name="location2")]
        public string Location2 { get; set; }

        [DataMember(Name="owner")]
        public string Owner { get; set; }

        [DataMember(Name="website")]
        public string Website { get; set; }
    }
}