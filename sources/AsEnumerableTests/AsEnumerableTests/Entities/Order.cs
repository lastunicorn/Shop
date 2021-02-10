using System;

namespace AsEnumerableTests.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Product Product { get; set; }

        public OrderState State { get; set; }

        public Payment Payment { get; set; }

        public bool IsFinished => State == OrderState.Done || State == OrderState.Canceled;
    }
}