using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
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

        public Sale GetFull(int id)
        {
            return Collection.First(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Collection.RemoveAll(x => x.Id == id);
        }

        public IEnumerable<Sale> GetInProgress(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}