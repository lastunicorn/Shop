using System;
using System.Collections.ObjectModel;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.DataAccess.InMemory
{
    internal class SaleCollection : Collection<Sale>
    {
        private int lastId;

        protected override void InsertItem(int index, Sale sale)
        {
            if (sale == null)
                throw new ArgumentNullException(nameof(sale));

            if (sale.Id != 0)
                throw new Exception("The sale should not have an assigned id.");

            if (Items.Contains(sale))
                throw new Exception("Sale is already present in the collection.");

            sale.Id = ++lastId;

            base.InsertItem(index, sale);
        }
    }
}