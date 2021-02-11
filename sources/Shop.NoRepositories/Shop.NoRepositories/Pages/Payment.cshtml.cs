using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.NoRepositories.Application.UseCases.BeginPayment;
using Shop.NoRepositories.Application.UseCases.CancelOrder;
using Shop.NoRepositories.Application.UseCases.CompletePayment;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly IMediator mediator;

        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public PaymentModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGet()
        {
            BeginPaymentRequest request = new BeginPaymentRequest
            {
                OrderId = OrderId
            };

            Order order = await mediator.Send(request);

            ProductName = order.Product.Name;
            Price = order.Product.Price;
        }

        public async Task<IActionResult> OnPostPay()
        {
            CompletePaymentRequest request = new CompletePaymentRequest
            {
                OrderId = OrderId
            };

            await mediator.Send(request);

            return RedirectToPage("Dispenser", new { OrderId = OrderId });
        }

        public async Task<IActionResult> OnPostCancel()
        {
            CancelOrderRequest request = new CancelOrderRequest
            {
                OrderId = OrderId
            };

            await mediator.Send(request);

            return RedirectToPage("Shelf");
        }
    }
}