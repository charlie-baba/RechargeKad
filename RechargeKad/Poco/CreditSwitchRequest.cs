using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RechargeKad.Poco
{
    [DataContract]
    public class CreditSwitchRequest
    {
        [DataMember(Name = "loginId")]
        public long LoginId { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "requestId")]
        public string RequestId { get; set; }

        [DataMember(Name = "serviceId")]
        public string ServiceId { get; set; }

        [DataMember(Name = "amount")]
        [Range(1, 100000)]
        public long Amount { get; set; }

        [DataMember(Name = "recipient")]
        public string Recipient { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "checksum")]
        public string Checksum { get; set; }
    }
}
