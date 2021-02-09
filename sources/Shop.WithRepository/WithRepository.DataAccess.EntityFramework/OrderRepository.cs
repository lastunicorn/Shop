using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }

        public Order GetFull(int id)
        {
            return DbContext.Orders
                .Include(x => x.Product)
                .Include(x => x.Payment)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAllFull()
        {
            return DbContext.Orders
                .Include(x => x.Product)
                .Include(x => x.Payment)
                .ToList();
        }

        public IEnumerable<Order> GetInProgress(int productId)
        {
            return DbContext.Orders
                .Include(x => x.Product)
                .Where(x => x.Product.Id == productId && x.State != OrderState.Done && x.State != OrderState.Canceled);
        }
    }
}