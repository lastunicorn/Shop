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

        public IEnumerable<Product> GetAvailable()
        {
            return DbContext.Products
                .Where(x => x.Quantity > 0);

            //return DbContext.Products
            //    .Join(DbContext.Sales, x => x, x => x.Product, (p, s) => new { Product = p, Sale = s })
            //    .GroupBy(x => x.Product)
            //    .Where(x => x.Key.Quantity > 0)
            //    .Select(x => x.Key);

            //return DbContext.Products
            //    .Select(x => new Product
            //    {
            //        Product = x,
            //        ReservedCount = DbContext.Sales.Count(z => z.Product == x && z.State != SaleState.Done)
            //    });
        }

        //public IEnumerable<ProductWithReservations2> GetAvailable()
        //{
        //    IQueryable<ProductWithReservations2> query = DbContext.Products
        //        .Select(x => new ProductWithReservations2
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Price = x.Price,
        //            Quantity = x.Quantity,
        //            ReservationCount = DbContext.Sales.Count(z => z.Product == x && z.State != SaleState.Done)
        //        });

        //    foreach (ProductWithReservations2 productWithReservations in query)
        //    {
        //        DbContext.Set<ProductWithReservations2>().Attach(productWithReservations);
        //        yield return productWithReservations;
        //    }
        //}

        public void Remove(int id)
        {
            Product product = DbContext.Products.Find(id);

            if (product != null)
                DbContext.Products.Remove(product);
        }
    }
}