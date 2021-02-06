using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public PaymentModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void OnGet(int productId)
        {
            //Product product = 
        }
    }
}
