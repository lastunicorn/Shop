using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.GetPaymentDetails
{
    internal class GetPaymentDetailsRequestHandler : IRequestHandler<GetPaymentDetailsRequest, Sale>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPaymentDetailsRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<Sale> Handle(GetPaymentDetailsRequest request, CancellationToken cancellationToken)
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