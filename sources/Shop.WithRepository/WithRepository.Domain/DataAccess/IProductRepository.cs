using System.Collections.Generic;

namespace Shop.WithRepository.Domain.DataAccess
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<ProductWithReservations> GetAvailable();
    }
}