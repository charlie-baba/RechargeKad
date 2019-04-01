using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RechargeKad.Config
{
    public class CreditSwitchConfig
    {
        public long MerchantId { get; set; }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public string BaseUrl { get; set; }

        public string AirtimePath { get; set; }

        public string DataPath { get; set; }
    }
}
