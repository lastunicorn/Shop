using Microsoft.EntityFrameworkCore;
using Shop.WithRepositories.DataAccess.EntityFramework.Configurations;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.DataAccess.EntityFramework
{
    public class RepositoryPatternDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductWithReservationsEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}