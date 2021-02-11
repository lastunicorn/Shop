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
                // todo: query
                Order order = shopDbContext.Orders
                    .Include(x => x.Product)
                    .Include(x => x.Payment)
                    .FirstOrDefault(x => x.Id == request.OrderId);

                if (order == null)
                    throw new OrderMissingException(request.OrderId);

                switch (order.State)
                {
                    case OrderState.New:
                        throw new OrderNotPayedException(order.Id);

                    case OrderState.Payed:
                        order.Product.Quantity--;
                        order.State = OrderState.Done;

                        shopDbContext.SaveChanges();

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