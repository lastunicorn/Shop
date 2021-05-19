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

        public void ValidateOrderIsReadyForPayment()
        {
            switch (State)
            {
                case OrderState.Payed:
                case OrderState.Done:
                    throw new PaymentCompletedException(Id);

                case OrderState.Canceled:
                    throw new OrderCanceledException(Id);

                case OrderState.New:
                    break;

                default:
                    throw new InvalidOrderStateException(Id);
            }
        }

        public void ValidateOrderIsReadyForCompletion()
        {
            switch (State)
            {
                case OrderState.New:
                    throw new OrderNotPayedException(Id);

                case OrderState.Payed:
                    break;

                case OrderState.Done:
                    throw new ProductAlreadyDispensedException(Product.Name);

                case OrderState.Canceled:
                    throw new OrderCanceledException(Id);

                default:
                    throw new InvalidOrderStateException(Id);
            }
        }

        public void ValidateOrderIsReadyForCanceling()
        {
            switch (State)
            {
                case OrderState.Payed:
                case OrderState.Done:
                    throw new PaymentCompletedException(Id);

                case OrderState.Canceled:
                    throw new OrderCanceledException(Id);

                case OrderState.New:
                    break;

                default:
                    throw new InvalidOrderStateException(Id);
            }
        }

        public void CompleteOrder()
        {
            Product.Quantity--;
            State = OrderState.Done;
        }

        public void SetOrderAsPayed()
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