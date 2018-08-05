using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightCancellationStatisticsResponse
    {
        [DataMember(Name="FlightCancellationStatisticsResult")]
        public CancellationSummaryStruct Results { get; set; }
    }
}