using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AsEnumerableTests.DataAccess;
using AsEnumerableTests.Entities;

namespace AsEnumerableTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (DemoDbContext dbContext = new DemoDbContext())
            {
                // Force Entity Framework to connect to the database.
                dbContext.Orders.FirstOrDefault();

                //CreateManyOrders(dbContext);
                PerformTests(dbContext);
            }
        }

        private static void CreateManyOrders(DemoDbContext dbContext)
        {
            for (int i = 0; i < 100000; i++)
            {
                dbContext.Orders.Add(new Order
                {
                    Date = DateTime.UtcNow
                });
            }

            dbContext.SaveChanges();
        }

        private static void PerformTests(DemoDbContext dbContext)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            IEnumerable<Order> orders = GetOrders(dbContext);

            long millis1 = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(millis1);
            stopwatch.Restart();

            foreach (Order order in orders)
            {
            }

            long millis2 = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(millis2);
            stopwatch.Restart();

            foreach (Order order in orders)
            {
            }

            stopwatch.Stop();
            long millis3 = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(millis3);
        }

        private static IEnumerable<Order> GetOrders(DemoDbContext dbContext)
        {
            return dbContext.Orders
                .ToList();

        }
    }
}