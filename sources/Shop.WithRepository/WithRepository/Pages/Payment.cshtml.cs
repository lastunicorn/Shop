using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.CancelSale;
using Shop.WithRepository.Application.GetPaymentDetails;
using Shop.WithRepository.Application.Pay;
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
            GetPaymentDetailsRequest request = new GetPaymentDetailsRequest
            {
                SaleId = SaleId
            };

            Sale sale = await mediator.Send(request);

            ProductName = sale.Product.Name;
            Price = sale.Product.Price;
        }

        public async Task<IActionResult> OnPostPay()
        {
            PayRequest request = new PayRequest
            {
                SaleId = SaleId
            };

            await mediator.Send(request);

            return RedirectToPage("SaleCompleted", new { SaleId = SaleId });
        }

        public async Task<IActionResult> OnPostCancel()
        {
            CancelSaleRequest request = new CancelSaleRequest
            {
                SaleId = SaleId
            };

            await mediator.Send(request);

            return RedirectToPage("Shelf");
        }
    }
}