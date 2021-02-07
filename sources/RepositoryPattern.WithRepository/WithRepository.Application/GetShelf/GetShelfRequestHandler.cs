using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.GetShelf
{
    internal class GetShelfRequestHandler : IRequestHandler<GetShelfRequest, List<Product>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetShelfRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<List<Product>> Handle(GetShelfRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                List<Product> products = unitOfWork.ProductRepository.GetAvailable().ToList();

                foreach (Product product in products)
                {
                    int reservationCount = unitOfWork.SaleRepository.GetInProgress(product.Id).Count();

                    product.Quantity -= reservationCount;
                }

                return products;
            }, cancellationToken);
        }
    }
}