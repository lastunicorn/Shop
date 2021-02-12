using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepositories.Application.UseCases.CompleteOrder;

namespace Shop.WithRepositories.Pages
{
    public class DispenserModel : PageModel
    {
        private readonly IMediator mediator;

        public string ProductName { get; set; }

        public DispenserModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGet(int orderId)
        {
            CompleteOrderRequest request = new CompleteOrderRequest
            {
                OrderId = orderId
            };

            CompleteOrderResponse response = await mediator.Send(request);

            ProductName = response.ProductName;
        }
    }
}