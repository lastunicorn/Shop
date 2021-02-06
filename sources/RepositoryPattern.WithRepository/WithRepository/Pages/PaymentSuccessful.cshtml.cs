using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.CompleteSale;
using Shop.WithRepository.Application.GetPaymentDetails;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Pages
{
    public class PaymentSuccessfulModel : PageModel
    {
        private readonly IMediator mediator;

        public string ProductName { get; set; }

        public PaymentSuccessfulModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGet(int saleId)
        {
            CompleteSaleRequest request = new CompleteSaleRequest
            {
                SaleId = saleId
            };

            CompleteSaleResponse response = await mediator.Send(request);

            ProductName = response.ProductName;
        }
    }
}