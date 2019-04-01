using RechargeKad.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RechargeKad.Model
{
    [Table("ServiceCode", Schema = "dbo")]
    public class ServiceCode : BaseEntity
    {
        [NotMapped]
        public NetworkType NetworkType { get; set; }

        [NotMapped]
        public RechargeType RechargeType { get; set; }

        [NotMapped]
        public Vendor Vendor { get; set; }

        public string Code { get; set; }


        [Column("NetworkType")]
        public string NetworkTypeString
        {
            get { return NetworkType.ToString(); }
            private set { NetworkType = value.ParseEnum<NetworkType>(); }
        }

        [Column("RechargeType")]
        public string RechargeTypeString
        {
            get { return RechargeType.ToString(); }
            private set { RechargeType = value.ParseEnum<RechargeType>(); }
        }
                
        [Column("Vendor")]
        public string VendorString
        {
            get { return Vendor.ToString(); }
            private set { Vendor = value.ParseEnum<Vendor>(); }
        }

    }
}
