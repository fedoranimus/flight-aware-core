using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class BlockIdentCheckResponse
    {
        [DataMember(Name="BlockIdentCheckResult")]
        public bool IsBlocked { get; set; }
    }
}