using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.Application.GetProducts
{
    public class GetProductsHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetProductsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<Product> Execute()
        {
            return unitOfWork.ProductRepository.GetAll().ToList();
        }
    }
}