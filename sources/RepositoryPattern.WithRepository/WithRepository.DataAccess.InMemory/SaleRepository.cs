using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.InMemory
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(List<Sale> collection)
            : base(collection)
        {
        }

        public Sale Get(int id)
        {
            return Collection.First(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Collection.RemoveAll(x => x.Id == id);
        }

        public IEnumerable<Sale> GetInProgressForProduct(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}