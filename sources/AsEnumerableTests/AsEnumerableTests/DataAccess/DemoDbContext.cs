using AsEnumerableTests.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsEnumerableTests.DataAccess
{
    internal class DemoDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}