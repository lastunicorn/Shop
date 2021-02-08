using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }

        public Sale Get(int id)
        {
            return DbContext.Sales
                .FirstOrDefault(x => x.Id == id);
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
                .Where(x => x.Product.Id == productId && x.State != SaleState.Done);
        }

        public void Remove(int id)
        {
            Sale sale = DbContext.Sales.Find(id);

            if (sale != null)
                DbContext.Sales.Remove(sale);
        }
    }
}