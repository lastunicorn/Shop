using System.Collections.Generic;
using RepositoryPattern.WithRepository.Domain;

namespace RepositoryPattern.WithRepository.DataAccess.InMemory
{
    internal static class InMemoryDatabase
    {
        public static List<Product> Products { get; } = new List<Product>();
        
        public static List<User> Users { get; } = new List<User>();

        static InMemoryDatabase()
        {
            Products.Add(new Product
            {
                Id = 1,
                Name = "Chocolate",
                Price = 12,
                Quantity = 3
            });

            Products.Add(new Product
            {
                Id = 2,
                Name = "Water",
                Price = 5,
                Quantity = 10
            });

            Products.Add(new Product
            {
                Id = 3,
                Name = "Chips",
                Price = 3,
                Quantity = 15
            });
        }
    }
}