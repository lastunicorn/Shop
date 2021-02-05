using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public List<ProductViewModel> Products { get; set; }

        public ProductsModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void OnGet()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetAll();

            Products = products
                .Select(x => new ProductViewModel
                {
                    Name = x.Name
                })
                .ToList();
        }
    }
}