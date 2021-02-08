using System.Collections.Generic;

namespace Shop.WithRepository.Domain.DataAccess
{
    public interface ISaleRepository : IRepository<Sale, int>
    {
        Sale GetFull(int id);

        IEnumerable<Sale> GetInProgress(int productId);
    }
}