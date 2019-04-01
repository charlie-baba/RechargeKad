using RechargeKad.Enums;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace RechargeKad.Util
{
    public class Utility
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string GetRequestId()
        {
            return Convert.ToString((long)(DateTime.UtcNow - epoch).TotalMilliseconds);
        }

        public static string CheckSum(long loginId, string transId, string serviceCode, 
            long amount, string privateKey, string phoneNumber)
        {
            string checkSum = $"{loginId}|{transId}|{serviceCode}|{amount}|{privateKey}|{phoneNumber}";
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(checkSum, salt);
            string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(hash));
            return base64String;
        }

    }
}
