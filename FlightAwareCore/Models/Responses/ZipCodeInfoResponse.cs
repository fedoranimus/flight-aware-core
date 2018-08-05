using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class ZipCodeInfoResponse
    {
        [DataMember(Name="ZipcodeInfoResult")]
        public ZipCodeInfoStruct ZipCodeInfo { get; set; }
    }
}