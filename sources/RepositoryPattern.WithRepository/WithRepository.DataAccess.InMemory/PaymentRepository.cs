using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.InMemory
{
    public class PaymentRepository : IPaymentRepository
    {
        public Payment Get(int id)
        {
            return InMemoryDatabase.Payments.Find(x => x.Id == id);
        }

        public IEnumerable<Payment> GetAll()
        {
            return InMemoryDatabase.Payments;
        }

        public Payment GetOneForProduct(int productId)
        {
            return InMemoryDatabase.Payments.Find(x => x.Product.Id == productId);
        }

        public void Add(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            bool entityAlreadyExists = InMemoryDatabase.Payments.Any(x => x.Id == payment.Id);

            if (entityAlreadyExists)
                throw new DataAccessException("Another payment with the same id already exists.");

            InMemoryDatabase.Payments.Add(payment);
        }

        public void AddBulk(IEnumerable<Payment> payments)
        {
            if (payments == null) throw new ArgumentNullException(nameof(payments));

            foreach (Payment payment in payments)
            {
                bool entityAlreadyExists = InMemoryDatabase.Payments.Any(x => x.Id == payment.Id);

                if (entityAlreadyExists)
                    throw new DataAccessException("Another payment with the same id already exists.");

                InMemoryDatabase.Payments.Add(payment);
            }
        }

        public void Remove(int id)
        {
            InMemoryDatabase.Payments.RemoveAll(x => x.Id == id);
        }

        public void Remove(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            InMemoryDatabase.Payments.Remove(payment);
        }

        public void RemoveBulk(IEnumerable<Payment> payments)
        {
            if (payments == null) throw new ArgumentNullException(nameof(payments));

            foreach (Payment payment in payments)
                InMemoryDatabase.Payments.Remove(payment);
        }
    }
}