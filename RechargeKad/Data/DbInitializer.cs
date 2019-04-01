using RechargeKad.Enums;
using System.Linq;
using RechargeKad.Model;

namespace RechargeKad.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RechargeKadDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.ServiceCodes.Any())
            {
                return;   // DB has been seeded
            }

            var serviceCodes = new ServiceCode[]
            {
                new ServiceCode() {NetworkType = NetworkType.AIRTEL, RechargeType = RechargeType.AIRTIME, Vendor = Vendor.CREDIT_SWITCH, Code = "A01E"},
                new ServiceCode() {NetworkType = NetworkType.ETISALAT, RechargeType = RechargeType.AIRTIME, Vendor = Vendor.CREDIT_SWITCH, Code = "A02E"},
                new ServiceCode() {NetworkType = NetworkType.GLOBACOM, RechargeType = RechargeType.AIRTIME, Vendor = Vendor.CREDIT_SWITCH, Code = "A03E"},
                new ServiceCode() {NetworkType = NetworkType.MTN, RechargeType = RechargeType.AIRTIME, Vendor = Vendor.CREDIT_SWITCH, Code = "A04E"},

                new ServiceCode() {NetworkType = NetworkType.AIRTEL, RechargeType = RechargeType.DATA, Vendor = Vendor.CREDIT_SWITCH, Code = "D01D"},
                new ServiceCode() {NetworkType = NetworkType.ETISALAT, RechargeType = RechargeType.DATA, Vendor = Vendor.CREDIT_SWITCH, Code = "D02D"},
                new ServiceCode() {NetworkType = NetworkType.GLOBACOM, RechargeType = RechargeType.DATA, Vendor = Vendor.CREDIT_SWITCH, Code = "D03D"},
                new ServiceCode() {NetworkType = NetworkType.MTN, RechargeType = RechargeType.DATA, Vendor = Vendor.CREDIT_SWITCH, Code = "D04D"},
            };
            foreach (ServiceCode s in serviceCodes)
            {
                context.ServiceCodes.Add(s);
            }
            context.SaveChanges();
        }
    }

}