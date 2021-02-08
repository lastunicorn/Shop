using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.BeginPayment;
using Shop.WithRepository.Application.CompletePayment;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly IMediator mediator;

        [BindProperty(SupportsGet = true)]
        public int SaleId { get; set; }

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
                SaleId = SaleId
            };

            Sale sale = await mediator.Send(request);

            ProductName = sale.Product.Name;
            Price = sale.Product.Price;
        }

        public async Task<IActionResult> OnPostPay()
        {
            CompletePaymentRequest request = new CompletePaymentRequest
            {
                SaleId = SaleId
            };

            await mediator.Send(request);

            return RedirectToPage("Dispenser", new { SaleId = SaleId });
        }

        public Task<IActionResult> OnPostCancel()
        {
            throw new NotImplementedException();
        }
    }
}