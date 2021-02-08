using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository()
            : base(InMemoryDatabase.Orders)
        {
        }

        protected override int GetIdFor(Order entity)
        {
            return entity.Id;
        }

        public Order GetFull(int id)
        {
            return Collection.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetInProgress(int productId)
        {
            return Collection
                .Where(x => x.Product.Id == productId && x.State != OrderState.Done && x.State != OrderState.Canceled);
        }
    }
}