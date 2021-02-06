using System.Collections.Generic;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.DataAccess.InMemory
{
    internal static class InMemoryDatabase
    {
        public static List<Product> Products { get; } = new List<Product>();
        
        public static List<Payment> Payments { get; } = new List<Payment>();
        
        public static List<Sale> Sales { get; } = new List<Sale>();

        static InMemoryDatabase()
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

            Products.AddRange(products);
        }
    }
}