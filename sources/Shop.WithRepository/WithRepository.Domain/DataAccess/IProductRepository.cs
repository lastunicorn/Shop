﻿using System.Collections.Generic;

namespace Shop.WithRepository.Domain.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(int id);

        IEnumerable<ProductWithReservations> GetAvailable();

        void Remove(int id);
    }
}