using System;

namespace Shop.WithRepository.Domain
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        
        public Product Product { get; set; }
        
        public SaleState State { get; set; }
        
        public Payment Payment { get; set; }
    }
}