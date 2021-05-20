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

        public void Complete()
        {
            Product.Quantity--;
            State = OrderState.Done;
        }

        public void SetAsPayed()
        {
            Payment payment = new Payment
            {
                Date = DateTime.UtcNow,
                Value = Product.Price
            };

            Payment = payment;
            State = OrderState.Payed;
        }

        public void Cancel()
        {
            State = OrderState.Canceled;
        }
    }
}