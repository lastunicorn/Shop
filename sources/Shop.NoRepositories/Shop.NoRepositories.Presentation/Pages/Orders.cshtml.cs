using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.NoRepositories.Application.UseCases.CancelOrder;
using Shop.NoRepositories.Application.UseCases.PresentOrders;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Presentation.Pages
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

        public async Task OnPostClose(Guid orderId)
        {
            CancelOrderRequest request = new CancelOrderRequest
            {
                OrderId = orderId
            };

            await mediator.Send(request);

            PresentOrdersRequest presentOrdersRequest = new PresentOrdersRequest();

            List<Order> orders = await mediator.Send(presentOrdersRequest);

            Orders = orders
                .Select(x => new OrderViewModel(x))
                .ToList();
        }

        public IActionResult OnPostPay(Guid orderId)
        {
            return RedirectToPage("Payment", new { OrderId = orderId });
        }
    }
}