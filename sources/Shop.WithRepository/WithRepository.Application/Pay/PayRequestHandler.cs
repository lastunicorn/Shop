using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.Pay
{
    internal class PayRequestHandler : AsyncRequestHandler<PayRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected override Task Handle(PayRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Sale sale = unitOfWork.SaleRepository.GetFull(request.SaleId);

                if (sale == null)
                    throw new ShopException("Specified sale does not exist.");

                switch (sale.State)
                {
                    case SaleState.Payed:
                    case SaleState.Done:
                        throw new ShopException("The payment was already done.");

                    case SaleState.Canceled:
                        throw new ShopException("The sale was canceled. Please make another sale.");
                }

                // Here, the application should call the bank and perform the money transfer.
                // Maybe a separate module will be created that encapsulates the details of accessing the bank's system.

                Payment payment = new Payment
                {
                    Date = DateTime.UtcNow,
                    Value = sale.Product.Price
                };

                sale.Payment = payment;
                sale.State = SaleState.Payed;

                unitOfWork.PaymentRepository.Add(payment);

                unitOfWork.Complete();
            }, cancellationToken);
        }
    }
}