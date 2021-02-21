using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.DataAccess.EntityFramework
{
    public static class DbSetOrderExtensions
    {
        public static Order Get(this DbSet<Order> orders, int id)
        {
            return orders
                .FirstOrDefault(x => x.Id == id);
        }

        public static Order GetFull(this DbSet<Order> orders, int id)
        {
            return orders
                .Include(x => x.Product)
                .Include(x => x.Payment)
                .FirstOrDefault(x => x.Id == id);
        }

        public static List<Order> GetAllFullByDate(this DbSet<Order> orders)
        {
            return orders
                .Include(x => x.Product)
                .Include(x => x.Payment)
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public static List<Order> GetInProgress(this DbSet<Order> orders, int productId)
        {
            return orders
                .Include(x => x.Product)
                .Where(x => x.Product.Id == productId && x.State != OrderState.Done && x.State != OrderState.Canceled)
                .ToList();
        }
    }
}