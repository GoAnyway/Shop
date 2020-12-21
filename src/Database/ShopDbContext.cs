using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public sealed class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Author)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Subdivisions)
                .WithOne(e => e.Manager)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Subdivision>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Subdivision)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Order)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}