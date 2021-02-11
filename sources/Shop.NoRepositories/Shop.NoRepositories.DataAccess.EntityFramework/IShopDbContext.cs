using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.DataAccess.EntityFramework
{
    public interface IShopDbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Payment> Payments { get; set; }

        DbSet<Order> Orders { get; set; }

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);

        void Dispose();
    }
}