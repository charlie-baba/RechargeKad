using RechargeKad.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeKad.Model
{
    [Table("RechargeTransaction", Schema = "dbo")]
    public class RechargeTransaction : BaseEntity
    {
        public double Amount { get; set; }

        public string TransactionId { get; set; }

        public string DealerCode { get; set; }

        public string PhoneNumber { get; set; }

        public string ServiceCode { get; set; }

        public string ConfirmCode { get; set; }

        public string Reference { get; set; }

        public DateTime? TransDate { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseDescription { get; set; }

        [NotMapped]
        public RechargeType RechargeType { get; set; }

        [NotMapped]
        public RequestType RequestType { get; set; }

        [NotMapped]
        public TransactionStatus Status { get; set; }


        [Column("RechargeType")]
        public string RechargeTypeString
        {
            get { return RechargeType.ToString(); }
            private set { RechargeType = value.ParseEnum<RechargeType>(); }
        }

        [Column("RequestType")]
        public string RequestTypeString
        {
            get { return RequestType.ToString(); }
            private set { RequestType = value.ParseEnum<RequestType>(); }
        }

        [Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<TransactionStatus>(); }
        }

    }
}
