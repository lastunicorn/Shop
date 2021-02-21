using System;
using System.Collections.Generic;
using System.Linq;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.InMemory
{
    public class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        public OrderRepository()
            : base(InMemoryDatabase.Orders)
        {
        }

        protected override Guid GetIdFor(Order entity)
        {
            return entity.Id;
        }

        public Order GetFull(Guid id)
        {
            return Collection.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAllFullByDate()
        {
            return Collection
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public IEnumerable<Order> GetInProgressFor(int productId)
        {
            return Collection
                .Where(x => x.Product.Id == productId && x.State != OrderState.Done && x.State != OrderState.Canceled);
        }
    }
}