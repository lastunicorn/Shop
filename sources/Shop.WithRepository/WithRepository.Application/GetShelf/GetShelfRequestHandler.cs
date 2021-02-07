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
    internal class GetShelfRequestHandler : IRequestHandler<GetShelfRequest, List<ProductWithReservations>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetShelfRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<List<ProductWithReservations>> Handle(GetShelfRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => GetProductWithReservations().ToList(), cancellationToken);
        }

        private IEnumerable<ProductWithReservations> GetProductWithReservations()
        {
            List<Product> products = unitOfWork.ProductRepository.GetAvailable().ToList();

            foreach (Product product in products)
            {
                IEnumerable<Sale> salesInProgress = unitOfWork.SaleRepository.GetInProgress(product.Id);

                yield return new ProductWithReservations
                {
                    Product = product,
                    Reservations = salesInProgress.ToList()
                };
            }
        }
    }
}