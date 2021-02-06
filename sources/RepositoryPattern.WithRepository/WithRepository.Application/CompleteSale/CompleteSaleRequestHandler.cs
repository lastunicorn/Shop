using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.CompleteSale
{
    internal class CompleteSaleRequestHandler : IRequestHandler<CompleteSaleRequest, CompleteSaleResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public CompleteSaleRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<CompleteSaleResponse> Handle(CompleteSaleRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Sale sale = unitOfWork.SaleRepository.GetFull(request.SaleId);

                if (sale == null)
                    throw new ShopException($"The specified sale ({request.SaleId}) does not exist.");

                sale.Product.Quantity--;
                sale.State = SaleState.Done;

                unitOfWork.Complete();

                return new CompleteSaleResponse
                {
                    ProductName = sale.Product.Name
                };

            }, cancellationToken);
        }
    }
}