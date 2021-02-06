using Microsoft.EntityFrameworkCore;
using RepositoryPattern.WithRepository.Domain;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
{
    public class RepositoryPatternDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Sale> Sale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Product[] products = new Product[]
            {
                new Product
                {
                    Id = 1,
                    Name = "Chocolate",
                    Price = 12,
                    Quantity = 3
                },
                new Product
                {
                    Id = 2,
                    Name = "Water",
                    Price = 5,
                    Quantity = 10
                },
                new Product
                {
                    Id = 3,
                    Name = "Chips",
                    Price = 3,
                    Quantity = 15
                }
            };

            modelBuilder.Entity<Product>().HasData(products);

            base.OnModelCreating(modelBuilder);
        }
    }
}