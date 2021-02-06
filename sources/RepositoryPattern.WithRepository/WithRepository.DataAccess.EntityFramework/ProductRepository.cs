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

        public void Remove(int id)
        {
            Product product = DbContext.Products.Find(id);

            if (product != null)
                DbContext.Products.Remove(product);
        }
    }
}