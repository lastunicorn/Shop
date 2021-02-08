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

        public Payment Get(int id)
        {
            return DbContext.Payments.Find(id);
        }

        public void Remove(int id)
        {
            Payment payment = DbContext.Payments.Find(id);

            if (payment != null)
                DbContext.Payments.Remove(payment);
        }
    }
}