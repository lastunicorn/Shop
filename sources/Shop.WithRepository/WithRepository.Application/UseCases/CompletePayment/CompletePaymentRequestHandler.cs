using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.UseCases.CompletePayment
{
    internal class CompletePaymentRequestHandler : AsyncRequestHandler<CompletePaymentRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CompletePaymentRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected override Task Handle(CompletePaymentRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Order order = unitOfWork.OrderRepository.GetFull(request.OrderId);

                if (order == null)
                    throw new OrderMissingException(request.OrderId);

                switch (order.State)
                {
                    case OrderState.Payed:
                    case OrderState.Done:
                        throw new PaymentCompletedException(order.Id);

                    case OrderState.Canceled:
                        throw new OrderCanceledException(order.Id);
                }

                // Here, the application should call the bank and perform the money transfer.
                // Maybe a separate module will be created that encapsulates the details of accessing the bank's system.

                Payment payment = new Payment
                {
                    Date = DateTime.UtcNow,
                    Value = order.Product.Price
                };

                order.Payment = payment;
                order.State = OrderState.Payed;

                unitOfWork.PaymentRepository.Add(payment);

                unitOfWork.Complete();
            }, cancellationToken);
        }
    }
}