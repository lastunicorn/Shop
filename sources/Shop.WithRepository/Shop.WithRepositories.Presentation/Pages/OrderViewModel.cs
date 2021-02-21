using System;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Presentation.Pages
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

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
            return order.State switch
            {
                OrderState.New => "New",
                OrderState.Payed => "Payed",
                OrderState.Done => "Completed",
                OrderState.Canceled => "Canceled",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}