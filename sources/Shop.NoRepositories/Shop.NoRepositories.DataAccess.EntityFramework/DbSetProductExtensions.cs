using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.DataAccess.EntityFramework
{
    public static class DbSetProductExtensions
    {
        public static Product GetById(this DbSet<Product> products, int productId)
        {
            return products.Find(productId);
        }
    }
}