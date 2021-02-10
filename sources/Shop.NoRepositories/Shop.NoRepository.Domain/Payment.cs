using System;

namespace Shop.NoRepository.Domain
{
    public class Payment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }
    }
}