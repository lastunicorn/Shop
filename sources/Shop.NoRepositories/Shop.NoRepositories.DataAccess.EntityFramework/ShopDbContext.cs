using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.DataAccess.EntityFramework.Configurations;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.DataAccess.EntityFramework
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductWithReservationsEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}