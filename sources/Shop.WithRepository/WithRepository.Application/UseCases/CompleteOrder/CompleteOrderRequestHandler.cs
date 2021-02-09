using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.UseCases.CompleteOrder
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
                Order order = unitOfWork.OrderRepository.GetFull(request.OrderId);

                if (order == null)
                    throw new OrderMissingException(request.OrderId);

                switch (order.State)
                {
                    case OrderState.New:
                        throw new OrderNotPayedException(order.Id);

                    case OrderState.Payed:
                        order.Product.Quantity--;
                        order.State = OrderState.Done;

                        unitOfWork.Complete();

                        return new CompleteOrderResponse
                        {
                            ProductName = order.Product.Name
                        };

                    case OrderState.Done:
                        throw new ProductAlreadyDispensedException(order.Product.Name);

                    default:
                        throw new InvalidOrderStateException(order.Id);
                }
            }, cancellationToken);
        }
    }
}