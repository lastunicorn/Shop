using Microsoft.EntityFrameworkCore;
using Shop.WithRepository.DataAccess.EntityFramework.Configurations;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class RepositoryPatternDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Sale> Sales { get; set; }

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