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
    }
}