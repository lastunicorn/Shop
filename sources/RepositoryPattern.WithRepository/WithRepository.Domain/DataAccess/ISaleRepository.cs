using System.Collections.Generic;

namespace Shop.WithRepository.Domain.DataAccess
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Sale Get(int id);

        void Remove(int id);

        IEnumerable<Sale> GetInProgressForProduct(int productId);
    }
}