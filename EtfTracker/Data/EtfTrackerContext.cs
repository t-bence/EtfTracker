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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exchange>()
                .Property(e => e.EurAmount)
                .HasConversion<double>();
            builder.Entity<Exchange>()
                .Property(e => e.EurRateInHuf)
                .HasConversion<double>();

            builder.Entity<Transfer>()
                .Property(e => e.EurAmount)
                .HasConversion<double>();

            builder.Entity<EtfPurchase>()
                .Property(e => e.EurPrice)
                .HasConversion<double>();
        }
    }
}
