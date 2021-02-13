using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.DataAccess.EntityFramework;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.CompleteOrder
{
    internal class CompleteOrderRequestHandler : IRequestHandler<CompleteOrderRequest, CompleteOrderResponse>
    {
        private readonly ShopDbContext shopDbContext;

        public CompleteOrderRequestHandler(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
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
            // todo: query
            Order order = shopDbContext.Orders
                .Include(x => x.Product)
                .Include(x => x.Payment)
                .FirstOrDefault(x => x.Id == request.OrderId);

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

            shopDbContext.SaveChanges();

            return new CompleteOrderResponse
            {
                ProductName = order.Product.Name
            };
        }
    }
}