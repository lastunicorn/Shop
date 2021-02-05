using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.Pages
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
            Product product = 
        }
    }
}
