using System.ComponentModel.DataAnnotations;

namespace RechargeKad.Poco
{
    public class VendRequest
    {
        [Required]
        public string PhoneNumber { get; set; }

        public string DealerCode { get; set; }

        [Required]
        public long Amount { get; set; }

        [Required]
        public string RechargeType { get; set; }

        [Required]
        public string NetworkType { get; set; }
    }
}
 