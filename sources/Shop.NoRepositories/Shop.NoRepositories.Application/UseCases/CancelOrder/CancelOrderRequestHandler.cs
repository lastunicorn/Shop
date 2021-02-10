using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.NoRepository.DataAccess.EntityFramework;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.CancelOrder
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
                // todo: query
                Order order = shopDbContext.Orders
                    .FirstOrDefault(x => x.Id == request.OrderId);

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

                shopDbContext.SaveChanges();
            }, cancellationToken);
        }
    }
}