using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.Application.UseCases.CompleteOrder
{
    internal class CompleteOrderRequestHandler : IRequestHandler<CompleteOrderRequest, CompleteOrderResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public CompleteOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CompleteOrderResponse> Handle(CompleteOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = RetrieveOrder(request.OrderId);
            ValidateOrderIsReadyForCompletion(order);
            order.Complete();

            await unitOfWork.CompleteAsync(cancellationToken);

            return new CompleteOrderResponse
            {
                ProductName = order.Product.Name
            };
        }

        private Order RetrieveOrder(Guid orderId)
        {
            Order order = unitOfWork.OrderRepository.GetFull(orderId);

            if (order == null)
                throw new OrderMissingException(orderId);

            return order;
        }

        private void ValidateOrderIsReadyForCompletion(Order order)
        {
            switch (order.State)
            {
                case OrderState.New:
                    throw new OrderNotPayedException(order.Id);

                case OrderState.Payed:
                    break;

                case OrderState.Done:
                    throw new ProductAlreadyDispensedException(order.Product.Name);

                case OrderState.Canceled:
                    throw new OrderCanceledException(order.Id);

                default:
                    throw new InvalidOrderStateException(order.Id);
            }
        }
    }
}