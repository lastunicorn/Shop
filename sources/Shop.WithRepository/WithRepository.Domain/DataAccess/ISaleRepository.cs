using System.Collections.Generic;

namespace Shop.WithRepository.Domain.DataAccess
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Sale Get(int id);

        Sale GetFull(int id);

        IEnumerable<Sale> GetInProgress(int productId);

        void Remove(int id);
    }
}