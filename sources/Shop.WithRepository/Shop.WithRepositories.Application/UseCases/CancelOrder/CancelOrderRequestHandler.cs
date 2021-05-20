using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.Application.UseCases.CancelOrder
{
    internal class CancelOrderRequestHandler : AsyncRequestHandler<CancelOrderRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CancelOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected override async Task Handle(CancelOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = RetrieveOrder(request);
            ValidateOrderIsReadyForCanceling(order);

            order.Cancel();

            await unitOfWork.CompleteAsync(cancellationToken);
        }

        private Order RetrieveOrder(CancelOrderRequest request)
        {
            Order order = unitOfWork.OrderRepository.Get(request.OrderId);

            if (order == null)
                throw new OrderMissingException(request.OrderId);

            return order;
        }

        public void ValidateOrderIsReadyForCanceling(Order order)
        {
            switch (order.State)
            {
                case OrderState.Payed:
                case OrderState.Done:
                    throw new PaymentCompletedException(order.Id);

                case OrderState.Canceled:
                    throw new OrderCanceledException(order.Id);

                case OrderState.New:
                    break;

                default:
                    throw new InvalidOrderStateException(order.Id);
            }
        }
    }
}