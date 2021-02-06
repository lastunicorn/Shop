using System;
using RepositoryPattern.WithRepository.Domain;

namespace RepositoryPattern.WithRepository.Pages
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ProductViewModel(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
        }
    }
}