using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(List<Product> collection)
            : base(collection)
        {
        }

        public Product Get(int id)
        {
            return Collection.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAvailable()
        {
            return Collection
                .Where(x => x.Quantity > 0);
        }

        public void Remove(int id)
        {
            Collection.RemoveAll(x => x.Id == id);
        }
    }
}