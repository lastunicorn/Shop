using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<Sale> GetInProgressForProduct(int productId)
        {
            return DbContext.Sale
                .Where(x => x.Product.Id == productId && x.State != SaleState.Done);
        }
    }
}