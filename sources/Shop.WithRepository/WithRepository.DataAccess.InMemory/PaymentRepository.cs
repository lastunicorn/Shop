using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
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