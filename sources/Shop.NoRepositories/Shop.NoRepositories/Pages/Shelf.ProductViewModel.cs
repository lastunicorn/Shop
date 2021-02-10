using System;
using Shop.NoRepository.Domain;

namespace Shop.NoRepositories.Pages
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int AvailableCount { get; set; }

        public int ReservationCount { get; set; }

        public bool CanBuy { get; set; }

        public ProductViewModel(ProductWithReservations product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            AvailableCount = product.Quantity - product.ReservationCount;
            ReservationCount = product.ReservationCount;
            CanBuy = AvailableCount > 0;
        }
    }
}