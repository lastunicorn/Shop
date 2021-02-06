using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.CreateSale
{
    public class CreateSaleRequestHandler : IRequestHandler<CreateSaleRequest, Sale>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateSaleRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<Sale> Handle(CreateSaleRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Product product = unitOfWork.ProductRepository.Get(request.ProductId);

                if (product == null)
                    throw new Exception("There is no product with the specified id.");

                List<Sale> inProgressSales = unitOfWork.SaleRepository.GetInProgressForProduct(product.Id).ToList();

                int availableQuantity = product.Quantity - inProgressSales.Count;

                if (availableQuantity <= 0)
                    throw new Exception($"There is no more {product.Name}.");

                Sale sale = new Sale
                {
                    Date = DateTime.UtcNow,
                    Product = product,
                    State = SaleState.New
                };

                unitOfWork.SaleRepository.Add(sale);

                unitOfWork.Complete();

                return sale;
            }, cancellationToken);
        }
    }
}