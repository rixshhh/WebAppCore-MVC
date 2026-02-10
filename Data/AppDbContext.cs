using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Students> Students { get; init; }

    public DbSet<Courses> Courses { get; init; }

    public DbSet<Subjects> Subjects { get; init; }

    public DbSet<Enrollments> Enrollments { get; init; }

    public DbSet<Attendence> Attendence { get; init; }

    public DbSet<Faculty> Faculty { get; set; }

    public DbSet<Fees> Fees { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(
    //        "Server=DESKTOP-0OS7L52\\SQLEXPRESS;Database=SIMS;Trusted_Connection=True;TrustServerCertificate=True"
    //    );
    //    base.OnConfiguring(optionsBuilder);
    //}
}