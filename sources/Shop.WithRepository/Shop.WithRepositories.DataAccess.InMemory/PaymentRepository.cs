using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.InMemory
{
    public class PaymentRepository : Repository<Payment, int>, IPaymentRepository
    {
        public PaymentRepository()
            : base(InMemoryDatabase.Payments)
        {
        }

        protected override int GetIdFor(Payment entity)
        {
            return entity.Id;
        }
    }
}