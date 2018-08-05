using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class CancellationSummaryStruct
    {
        [DataMember(Name="matching")]
        public IEnumerable<CancellationRowStruct> FlightStatistics { get; set; }

        [DataMember(Name="next_offset")]
        public int NextOffset { get; set; }

        [DataMember(Name="total_cancellations_national")]
        public int TotalCancellationsNationwide { get; set; }

        [DataMember(Name="total_cancellations_worldwide")]
        public int TotalCancellationsWorldwide { get; set; }

        [DataMember(Name="total_delays_worldwide")]
        public int TotalDelaysWorldwide { get; set; }

        [DataMember(Name="type_matching")]
        public string TypeMatching { get; set; }
    }
}