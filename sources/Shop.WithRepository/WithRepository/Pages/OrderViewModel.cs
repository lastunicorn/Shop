using System;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Pages
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string ProductName { get; set; }

        public OrderState State { get; set; }

        public bool ShowCloseButton { get; set; }
        
        public bool ShowPaymentButton { get; set; }

        public OrderViewModel(Order order)
        {
            Id = order.Id;
            Date = order.Date;
            ProductName = order.Product?.Name;
            State = order.State;
            ShowCloseButton = !order.IsFinished;
            ShowPaymentButton = order.State == OrderState.New;
        }
    }
}