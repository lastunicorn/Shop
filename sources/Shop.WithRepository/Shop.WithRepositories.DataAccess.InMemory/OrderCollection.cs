﻿using System;
using System.Collections.ObjectModel;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.DataAccess.InMemory
{
    internal class OrderCollection : Collection<Order>
    {
        protected override void InsertItem(int index, Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (order.Id != Guid.Empty)
                throw new Exception("The order should not have an assigned id.");

            if (Items.Contains(order))
                throw new Exception("Order is already present in the collection.");

            order.Id = Guid.NewGuid();

            base.InsertItem(index, order);
        }
    }
}