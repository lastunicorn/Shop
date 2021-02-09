using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.BeginPayment
{
    internal class BeginPaymentRequestHandler : IRequestHandler<BeginPaymentRequest, Order>
    {
        private readonly IUnitOfWork unitOfWork;

        public BeginPaymentRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<Order> Handle(BeginPaymentRequest request, CancellationToken cancellationToken)
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

                return order;
            }, cancellationToken);
        }
    }
}