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

        protected override Task Handle(CancelOrderRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Order order = unitOfWork.OrderRepository.Get(request.OrderId);

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

                order.State = OrderState.Canceled;

                unitOfWork.Complete();
            }, cancellationToken);
        }
    }
}