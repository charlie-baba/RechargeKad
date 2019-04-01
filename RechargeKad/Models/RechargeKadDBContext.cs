using Microsoft.EntityFrameworkCore;

namespace RechargeKad.Model
{
    public class RechargeKadDBContext : DbContext
    {
        public RechargeKadDBContext(DbContextOptions<RechargeKadDBContext> options)
            : base(options)
        { }

        public DbSet<RechargeTransaction> RechargeTransactions { get; set; }
        public DbSet<ServiceCode> ServiceCodes { get; set; }
        
    }
}
