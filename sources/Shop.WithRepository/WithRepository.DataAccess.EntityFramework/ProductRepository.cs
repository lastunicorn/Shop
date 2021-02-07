using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }

        public Product Get(int id)
        {
            return DbContext.Products.Find(id);
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
                    ReservationCount = DbContext.Sales.Count(z => z.Product == x && z.State != SaleState.Done)
                });

            foreach (ProductWithReservations productWithReservations in query)
            {
                DbContext.Set<ProductWithReservations>().Attach(productWithReservations);
                yield return productWithReservations;
            }
        }

        public void Remove(int id)
        {
            Product product = DbContext.Products.Find(id);

            if (product != null)
                DbContext.Products.Remove(product);
        }
    }
}