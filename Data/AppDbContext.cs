using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Students> Students { get; init; }
        
        public DbSet<Courses> Courses { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-0OS7L52\\SQLEXPRESS;Database=SIMS;Trusted_Connection=True;TrustServerCertificate=True"
            );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
