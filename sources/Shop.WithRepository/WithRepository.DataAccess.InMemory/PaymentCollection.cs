using System;
using System.Collections.ObjectModel;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.DataAccess.InMemory
{
    internal class PaymentCollection : Collection<Payment>
    {
        private int lastId;

        protected override void InsertItem(int index, Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            if (payment.Id != 0)
                throw new Exception("The payment should not have an assigned id.");

            if (Items.Contains(payment))
                throw new Exception("Payment is already present in the collection.");

            payment.Id = ++lastId;

            base.InsertItem(index, payment);
        }
    }
}