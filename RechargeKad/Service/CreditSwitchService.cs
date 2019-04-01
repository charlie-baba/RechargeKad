using RechargeKad.Config;
using RechargeKad.Model;
using RechargeKad.Poco;
using RechargeKad.Util;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RechargeKad.Service 
{
    public class CreditSwitchService 
    {
        //static readonly HttpClient client = new HttpClient();

        public static CreditSwitchRequest GetRequest(RechargeTransaction trans, CreditSwitchConfig config)
        {
            long amt = Convert.ToInt64(trans.Amount);
            string checkSum = Utility.CheckSum(config.MerchantId, trans.TransactionId, trans.ServiceCode, amt, config.PrivateKey, trans.PhoneNumber);

            CreditSwitchRequest req = new CreditSwitchRequest
            {
                LoginId = config.MerchantId,
                Key = config.PublicKey,
                RequestId = trans.TransactionId,
                ServiceId = trans.ServiceCode,
                Amount = amt,
                Recipient = trans.PhoneNumber,
                Date = DateTime.Now.ToUniversalTime().ToString("dd-MMM-yyyy hh:mm 'GMT'"),
                Checksum = checkSum
            };
            return req;
        }
        
    }
}
