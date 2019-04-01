using System;
using System.Runtime.Serialization;

namespace RechargeKad.Poco
{
    [DataContract]
    public class CreditSwitchRespose
    {
        [DataMember(Name = "statusCode")]
        public string StatusCode  { get; set; }

        [DataMember(Name = "statusDescription")]
        public string StatusDescription { get; set; }

        [DataMember(Name = "mReference")]
        public string MReference { get; set; }

        [DataMember(Name = "tranxReference")]
        public string TranxReference { get; set; }

        [DataMember(Name = "recipient")]
        public string Recipient { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "confirmCode")]
        public string ConfirmCode { get; set; }

        [DataMember(Name = "tranxDate")]
        public DateTime? TranxDate { get; set; }
    }
}
