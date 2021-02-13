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

        public Task<CompleteOrderResponse> Handle(CompleteOrderRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Order order = RetrieveOrder(request);
                ValidateOrderIsReadyForCompletion(order);

                return CompleteOrder(order);
            }, cancellationToken);
        }

        private Order RetrieveOrder(CompleteOrderRequest request)
        {
            Order order = unitOfWork.OrderRepository.GetFull(request.OrderId);

            if (order == null)
                throw new OrderMissingException(request.OrderId);

            return order;
        }

        private static void ValidateOrderIsReadyForCompletion(Order order)
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

        private CompleteOrderResponse CompleteOrder(Order order)
        {
            order.Product.Quantity--;
            order.State = OrderState.Done;

            unitOfWork.Complete();

            return new CompleteOrderResponse
            {
                ProductName = order.Product.Name
            };
        }
    }
}