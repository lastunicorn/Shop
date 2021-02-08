using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class SaleRepository : Repository<Sale, int>, ISaleRepository
    {
        public SaleRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }

        public Sale GetFull(int id)
        {
            return DbContext.Sales
                .Include(x => x.Product)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Sale> GetInProgress(int productId)
        {
            return DbContext.Sales
                .Include(x => x.Product)
                .Where(x => x.Product.Id == productId && x.State != SaleState.Done && x.State != SaleState.Canceled);
        }
    }
}