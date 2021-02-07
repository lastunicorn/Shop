using System.Collections.Generic;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.GetShelf
{
    public class ProductWithReservations
    {
        public Product Product { get; set; }

        public List<Sale> Reservations { get; set; }
    }
}