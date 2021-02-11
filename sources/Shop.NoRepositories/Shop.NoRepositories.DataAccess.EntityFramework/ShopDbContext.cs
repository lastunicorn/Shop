using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.DataAccess.EntityFramework.Configurations;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.DataAccess.EntityFramework
{
    public class ShopDbContext : DbContext, IShopDbContext
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