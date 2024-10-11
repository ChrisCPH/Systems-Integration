using Microsoft.EntityFrameworkCore;
using RentalService.Models;

namespace RentalService.Data
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {
        }

        public DbSet<RentalModel> Rental { get; set; }
    }
}
