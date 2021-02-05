using Microsoft.EntityFrameworkCore;
using RepositoryPattern.WithRepository.Domain;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
{
    public class RepositoryPatternDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}