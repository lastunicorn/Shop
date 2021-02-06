using System.Linq;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }

        public Payment GetOneForProduct(int productId)
        {
            return DbContext.Payments
                .FirstOrDefault(x => x.Product.Id == productId);
        }
    }
}