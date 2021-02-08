using System;
using System.Collections.ObjectModel;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.DataAccess.InMemory
{
    internal class OrderCollection : Collection<Order>
    {
        private int lastId;

        protected override void InsertItem(int index, Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (order.Id != 0)
                throw new Exception("The order should not have an assigned id.");

            if (Items.Contains(order))
                throw new Exception("Order is already present in the collection.");

            order.Id = ++lastId;

            base.InsertItem(index, order);
        }
    }
}