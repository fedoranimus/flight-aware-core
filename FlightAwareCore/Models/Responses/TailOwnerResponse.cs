using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class TailOwnerResponse
    {
        [DataMember(Name="TailOwnerResult")]
        public TailOwnerStruct TailOwner { get; set; }
    }
}