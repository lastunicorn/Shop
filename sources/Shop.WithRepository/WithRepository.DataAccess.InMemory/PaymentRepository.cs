using System.Collections.Generic;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(List<Payment> collection)
            : base(collection)
        {
        }

        public Payment Get(int id)
        {
            return Collection.Find(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Collection.RemoveAll(x => x.Id == id);
        }
    }
}