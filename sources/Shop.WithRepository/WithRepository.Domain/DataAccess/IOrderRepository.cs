using System.Collections.Generic;

namespace Shop.WithRepository.Domain.DataAccess
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        Order GetFull(int id);

        List<Order> GetAllFull();

        IEnumerable<Order> GetInProgress(int productId);
    }
}