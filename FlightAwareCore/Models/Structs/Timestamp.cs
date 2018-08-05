using System;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class Timestamp 
    {
        public DateTimeOffset? Epoch => EpochUnix?.ToDateTimeOffsetFromUnixTimestamp();

        [DataMember(Name="epoch")]
        internal long? EpochUnix { get; set; }
        [DataMember(Name="tz")]
        public string Tz { get; set; }
        [DataMember(Name="dow")]
        public string Dow { get; set; }
        [DataMember(Name="time")]
        public string Time { get; set; }
        [DataMember(Name="date")]
        public string Date { get; set; }
        [DataMember(Name="localtime")]
        internal long? LocalUnix { get; set; }
        public DateTimeOffset? LocalTime => LocalUnix?.ToDateTimeOffsetFromUnixTimestamp();
    }
}