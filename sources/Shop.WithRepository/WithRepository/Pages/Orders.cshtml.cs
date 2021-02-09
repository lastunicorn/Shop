using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.PresentOrders;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly IMediator mediator;

        public List<OrderViewModel> Orders { get; set; }

        public OrdersModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGet()
        {
            PresentOrdersRequest request = new PresentOrdersRequest();

            List<Order> orders = await mediator.Send(request);

            Orders = orders
                .Select(x => new OrderViewModel(x))
                .ToList();
        }

        public Task OnPostClose(int orderId)
        {
            throw new NotImplementedException();
        }

        public IActionResult OnPostPay(int orderId)
        {
            return RedirectToPage("Payment", new { OrderId = orderId });
        }
    }
}