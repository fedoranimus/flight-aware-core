using System.Runtime.Serialization;

namespace FlightAware.Models
{
    [DataContract]
    public class CancellationRowStruct
    {
        [DataMember(Name="cancellations")]
        public int Cancellations { get; set; }

        [DataMember(Name="delays")]
        public int Delays { get; set; }

        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="ident")]
        public string Ident { get; set; }

        [DataMember(Name="total")]
        public int Total { get; set; }   
    }
}