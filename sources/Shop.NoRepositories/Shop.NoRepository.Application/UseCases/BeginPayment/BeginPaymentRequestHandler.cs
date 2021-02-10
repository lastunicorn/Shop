using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepository.DataAccess.EntityFramework;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.BeginPayment
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
                // todo: query
                Order order = shopDbContext.Orders
                    .Include(x => x.Product)
                    .Include(x => x.Payment)
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

                return order;
            }, cancellationToken);
        }
    }
}