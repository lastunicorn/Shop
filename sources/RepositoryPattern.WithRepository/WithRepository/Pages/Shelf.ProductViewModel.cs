using System;
using Shop.WithRepository.Application.GetShelf;

namespace Shop.WithRepository.Pages
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

            Id = product.Product.Id;
            Name = product.Product.Name;
            Price = product.Product.Price;
            AvailableCount = product.Product.Quantity - product.Reservations.Count;
            ReservationCount = product.Reservations.Count;
            CanBuy = AvailableCount - ReservationCount > 0;
        }
    }
}