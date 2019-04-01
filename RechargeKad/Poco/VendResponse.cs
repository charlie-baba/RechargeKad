using System;

namespace RechargeKad.Poco
{
    public class VendResponse
    {
        public string TransactionId { get; set; }

        public string PhoneNumber { get; set; }

        public string DealerCode { get; set; }

        public long Amount { get; set; }

        public bool Success { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }
    }
}
