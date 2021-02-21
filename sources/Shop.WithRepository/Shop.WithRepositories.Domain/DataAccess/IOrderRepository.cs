﻿using System;
using System.Collections.Generic;

namespace Shop.WithRepositories.Domain.DataAccess
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Order GetFull(Guid id);

        List<Order> GetAllFull();

        IEnumerable<Order> GetInProgressFor(int productId);
    }
}