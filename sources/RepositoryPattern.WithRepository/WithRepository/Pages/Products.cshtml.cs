using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Application.GetProducts;
using Shop.WithRepository.Application.StartSale;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IMediator mediator;

        public List<ProductViewModel> Products { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        public ProductsModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGet()
        {
            GetProductsRequest request = new GetProductsRequest();
            List<Product> products = await mediator.Send(request);

            Products = products
                .Select(x => new ProductViewModel(x))
                .ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                StartSaleRequest request = new StartSaleRequest
                {
                    ProductId = ProductId
                };

                Sale sale = await mediator.Send(request);

                return RedirectToPage("Payment", new { SaleId = sale.Id });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}