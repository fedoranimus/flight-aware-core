using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class ZipCodeInfoResponse
    {
        [DataMember(Name="ZipCodeInfoResult")]
        public ZipCodeInfoStruct ZipCodeInfo { get; set; }
    }
}