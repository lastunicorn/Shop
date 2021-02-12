using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.DataAccess.EntityFramework
{
    public static class DbSetOrderExtensions
    {
        public static List<Order> GetInProgress(this DbSet<Order> orders, int productId)
        {
            return orders
                .Include(x => x.Product)
                .Where(x => x.Product.Id == productId && x.State != OrderState.Done && x.State != OrderState.Canceled)
                .ToList();
        }
    }
}