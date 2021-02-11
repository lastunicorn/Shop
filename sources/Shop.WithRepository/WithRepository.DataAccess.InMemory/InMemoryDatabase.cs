using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.DataAccess.InMemory
{
    internal static class InMemoryDatabase
    {
        public static ProductCollection Products { get; } = new ProductCollection();

        public static PaymentCollection Payments { get; } = new PaymentCollection();

        public static OrderCollection Orders { get; } = new OrderCollection();

        static InMemoryDatabase()
        {
            PopulateDatabase();
        }

        private static void PopulateDatabase()
        {
            Product[] products = new Product[]
            {
                new Product
                {
                    Name = "Chocolate",
                    Price = 12,
                    Quantity = 3
                },
                new Product
                {
                    Name = "Water",
                    Price = 5,
                    Quantity = 10
                },
                new Product
                {
                    Name = "Chips",
                    Price = 3,
                    Quantity = 15
                }
            };

            foreach (Product product in products)
                Products.Add(product);
        }
    }
}