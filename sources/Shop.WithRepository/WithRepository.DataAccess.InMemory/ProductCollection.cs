using System;
using System.Collections.ObjectModel;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.DataAccess.InMemory
{
    internal class ProductCollection : Collection<Product>
    {
        private int lastId;

        protected override void InsertItem(int index, Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (product.Id != 0)
                throw new Exception("The product should not have an assigned id.");

            if (Items.Contains(product))
                throw new Exception("Product is already present in the collection.");

            product.Id = ++lastId;

            base.InsertItem(index, product);
        }
    }
}