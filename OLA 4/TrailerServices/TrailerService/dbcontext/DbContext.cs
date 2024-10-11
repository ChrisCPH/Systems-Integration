using Microsoft.EntityFrameworkCore;
using TrailerService.Models;

namespace TrailerService.Data
{
    public class TrailerContext : DbContext
    {
        public TrailerContext(DbContextOptions<TrailerContext> options) : base(options)
        {
        }

        public DbSet<TrailerModel> Trailer { get; set; }
    }
}
