using System.Collections.Generic;
using System.Linq;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.EntityFramework
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<ProductWithReservations> GetAvailable()
        {
            IQueryable<ProductWithReservations> query = DbContext.Products
                .Select(x => new ProductWithReservations
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    ReservationCount = DbContext.Orders.Count(z => z.Product == x && z.State != OrderState.Done && z.State != OrderState.Canceled)
                });

            foreach (ProductWithReservations productWithReservations in query)
            {
                DbContext.Set<ProductWithReservations>().Attach(productWithReservations);
                yield return productWithReservations;
            }
        }
    }
}