using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.NoRepositories.DataAccess.EntityFramework;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.CancelOrder
{
    internal class CancelOrderRequestHandler : AsyncRequestHandler<CancelOrderRequest>
    {
        private readonly ShopDbContext shopDbContext;

        public CancelOrderRequestHandler(ShopDbContext unitOfWork)
        {
            this.shopDbContext = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected override Task Handle(CancelOrderRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Order order = RetrieveOrder(request);
                ValidateOrderIsReadyForCanceling(order);

                CancelOrder(order);

                shopDbContext.SaveChanges();
            }, cancellationToken);
        }

        private Order RetrieveOrder(CancelOrderRequest request)
        {
            // todo: query
            Order order = shopDbContext.Orders.Get(request.OrderId);

            if (order == null)
                throw new OrderMissingException(request.OrderId);

            return order;
        }

        private static void ValidateOrderIsReadyForCanceling(Order order)
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

        private static void CancelOrder(Order order)
        {
            order.State = OrderState.Canceled;
        }
    }
}