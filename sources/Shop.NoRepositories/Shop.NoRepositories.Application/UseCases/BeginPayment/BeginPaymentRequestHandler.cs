using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.DataAccess.EntityFramework;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.BeginPayment
{
    internal class BeginPaymentRequestHandler : IRequestHandler<BeginPaymentRequest, Order>
    {
        private readonly ShopDbContext shopDbContext;

        public BeginPaymentRequestHandler(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        public Task<Order> Handle(BeginPaymentRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Order order = RetrieveOrder(request);
                ValidateOrderIsReadyForPayment(order);

                return order;
            }, cancellationToken);
        }

        private Order RetrieveOrder(BeginPaymentRequest request)
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

        private static void ValidateOrderIsReadyForPayment(Order order)
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
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}