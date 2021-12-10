using Microsoft.EntityFrameworkCore;
using EtfTracker.Models;

namespace EtfTracker.Data
{
    public class EtfTrackerContext : DbContext
    {
        public EtfTrackerContext (DbContextOptions<EtfTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Exchange> Exchange { get; set; }

        public DbSet<Transfer> Transfer { get; set; }

        public DbSet<EtfPurchase> EtfPurchase { get; set; }
    }
}
