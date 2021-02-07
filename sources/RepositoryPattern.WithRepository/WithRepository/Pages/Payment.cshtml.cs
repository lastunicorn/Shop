using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.GetPaymentDetails;
using Shop.WithRepository.Application.Pay;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly IMediator mediator;

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public PaymentModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGet(int saleId)
        {
            GetPaymentDetailsRequest request = new GetPaymentDetailsRequest
            {
                SaleId = saleId
            };

            Sale sale = await mediator.Send(request);

            ProductName = sale.Product.Name;
            Price = sale.Product.Price;
        }

        public async Task<IActionResult> OnPost(int saleId)
        {
            PayRequest request = new PayRequest
            {
                SaleId = saleId
            };

            await mediator.Send(request);

            return RedirectToPage("SaleCompleted", new { SaleId = saleId });
        }
    }
}