using System.Linq;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
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