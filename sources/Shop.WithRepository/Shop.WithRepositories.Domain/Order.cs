using System;

namespace Shop.WithRepositories.Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Product Product { get; set; }

        public OrderState State { get; set; }

        public Payment Payment { get; set; }

        public bool IsFinished => State == OrderState.Done || State == OrderState.Canceled;
    }
}