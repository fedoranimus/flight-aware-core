using System;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class Timestamp 
    {
        [DataMember(Name="epoch")]
        public DateTime? Epoch { get; set; }
        [DataMember(Name="tz")]
        public string Tz { get; set; }
        [DataMember(Name="dow")]
        public string Dow { get; set; }
        [DataMember(Name="time")]
        public string Time { get; set; }
        [DataMember(Name="date")]
        public string Date { get; set; }
        [DataMember(Name="localtime")]
        public DateTime? LocalTime { get; set; }
    }
}