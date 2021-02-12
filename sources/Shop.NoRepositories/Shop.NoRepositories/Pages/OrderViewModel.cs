using System;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Pages
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string ProductName { get; set; }

        public string State { get; set; }

        public bool ShowCloseButton { get; set; }
        
        public bool ShowPaymentButton { get; set; }

        public OrderViewModel(Order order)
        {
            Id = order.Id;
            Date = order.Date;
            ProductName = order.Product?.Name;
            State = CalculateStateText(order);
            ShowCloseButton = !order.IsFinished;
            ShowPaymentButton = order.State == OrderState.New;
        }

        private static string CalculateStateText(Order order)
        {
            switch (order.State)
            {
                case OrderState.New:
                    return "New";

                case OrderState.Payed:
                    return "Payed";

                case OrderState.Done:
                    return "Completed";

                case OrderState.Canceled:
                    return "Canceled";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}