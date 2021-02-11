using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.DataAccess.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Product[] products = CreateInitialProducts();

            builder
                .HasData(products);
        }

        private static Product[] CreateInitialProducts()
        {
            return new Product[]
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
        }
    }
}