using System.Collections.Generic;

namespace RepositoryPattern.WithRepository.Domain.DataAccess
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Sale Get(int id);

        void Remove(int id);

        IEnumerable<Sale> GetInProgressForProduct(int productId);
    }
}