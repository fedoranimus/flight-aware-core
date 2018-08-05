using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class FlightCancellationStatisticsResponse
    {
        [DataMember]
        public CancellationSummaryStruct CancellationSummary { get; set; }
    }
}