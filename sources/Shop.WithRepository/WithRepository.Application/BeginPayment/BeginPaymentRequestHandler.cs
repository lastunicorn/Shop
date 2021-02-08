using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.BeginPayment
{
    internal class BeginPaymentRequestHandler : IRequestHandler<BeginPaymentRequest, Sale>
    {
        private readonly IUnitOfWork unitOfWork;

        public BeginPaymentRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<Sale> Handle(BeginPaymentRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Sale sale = unitOfWork.SaleRepository.GetFull(request.SaleId);

                if (sale == null)
                    throw new ShopException($"The specified sale ({request.SaleId}) does not exist.");

                return sale;
            }, cancellationToken);
        }
    }
}