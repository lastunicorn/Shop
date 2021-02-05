using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryPattern.WithRepository.Application.BuyProduct;
using RepositoryPattern.WithRepository.Application.GetProducts;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly GetProductsHandler getProductsHandler;
        private readonly BuyProductHandler buyProductHandler;

        public List<ProductViewModel> Products { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        public ProductsModel(IUnitOfWork unitOfWork, GetProductsHandler getProductsHandler, BuyProductHandler buyProductHandler)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.getProductsHandler = getProductsHandler ?? throw new ArgumentNullException(nameof(getProductsHandler));
            this.buyProductHandler = buyProductHandler ?? throw new ArgumentNullException(nameof(buyProductHandler));
        }

        public void OnGet()
        {
            IEnumerable<Product> products = getProductsHandler.Execute();

            Products = products
                .Select(x => new ProductViewModel(x))
                .ToList();
        }

        public IActionResult OnPost()
        {
            BuyProductRequest request = new BuyProductRequest
            {
                ProductId = 1
            };

            BuyProductResponse response = buyProductHandler.Execute(request);

            switch (response.BuyState)
            {
                case BuyState.Unknown:
                    break;

                case BuyState.PaymentNeeded:
                    // redirect to payment page
                    return RedirectToPage("Payment", new { ProductId = response.ProductId });

                case BuyState.Success:
                    // display 
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return BadRequest();
        }
    }
}