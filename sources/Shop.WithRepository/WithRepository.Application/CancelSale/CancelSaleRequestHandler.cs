using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.CancelSale
{
    internal class CancelSaleRequestHandler : AsyncRequestHandler<CancelSaleRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CancelSaleRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected override Task Handle(CancelSaleRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Sale sale = unitOfWork.SaleRepository.Get(request.SaleId);

                if (sale == null)
                    throw new ShopException($"The sale with id {request.SaleId} does not exist.");

                sale.State = SaleState.Canceled;

                unitOfWork.Complete();
            }, cancellationToken);
        }
    }
}