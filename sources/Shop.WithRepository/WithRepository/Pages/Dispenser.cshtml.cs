using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.CompleteSale;

namespace Shop.WithRepository.Pages
{
    public class DispenserModel : PageModel
    {
        private readonly IMediator mediator;

        public string ProductName { get; set; }

        public DispenserModel(IMediator mediator)
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