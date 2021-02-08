using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public class SaleRepository : Repository<Sale, int>, ISaleRepository
    {
        public SaleRepository()
            : base(InMemoryDatabase.Sales)
        {
        }

        protected override int GetIdFor(Sale entity)
        {
            return entity.Id;
        }

        public Sale GetFull(int id)
        {
            return Collection.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Sale> GetInProgress(int productId)
        {
            return Collection
                .Where(x => x.Product.Id == productId && (x.State != SaleState.Done || x.State != SaleState.Canceled));
        }
    }
}