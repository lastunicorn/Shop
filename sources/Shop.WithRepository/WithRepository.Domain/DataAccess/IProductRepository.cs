using System.Collections.Generic;

namespace Shop.WithRepositories.Domain.DataAccess
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<ProductWithReservations> GetAvailable();
    }
}