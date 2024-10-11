using Microsoft.EntityFrameworkCore;
using TrailerMonolith.Models;

namespace TrailerMonolith.Data
{
    public class TrailerMonolithContext : DbContext
    {
        public TrailerMonolithContext(DbContextOptions<TrailerMonolithContext> options) : base(options)
        {
        }

        public DbSet<TrailerModel> Trailer { get; set; }
        public DbSet<PaymentModel> Payment { get; set; }
        public DbSet<RentalModel> Rental { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrailerModel>(entity =>
            {
                entity.HasKey(t => t.TrailerID);
            });

            modelBuilder.Entity<RentalModel>(entity =>
            {
                entity.HasKey(r => r.RentalID);
            });

            modelBuilder.Entity<PaymentModel>(entity =>
            {
                entity.HasKey(p => p.PaymentID);
            });
        }
    }
}
