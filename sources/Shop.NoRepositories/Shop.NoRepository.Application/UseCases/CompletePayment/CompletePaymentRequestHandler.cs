using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepository.DataAccess.EntityFramework;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.CompletePayment
{
    internal class CompletePaymentRequestHandler : AsyncRequestHandler<CompletePaymentRequest>
    {
        private readonly ShopDbContext shopDbContext;

        public CompletePaymentRequestHandler(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        protected override Task Handle(CompletePaymentRequest request, CancellationToken cancellationToken)
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

                // Here, the application should call the bank and perform the money transfer.
                // Maybe a separate module will be created that encapsulates the details of accessing the bank's system.

                Payment payment = new Payment
                {
                    Date = DateTime.UtcNow,
                    Value = order.Product.Price
                };

                order.Payment = payment;
                order.State = OrderState.Payed;

                shopDbContext.Payments.Add(payment);

                shopDbContext.SaveChanges();
            }, cancellationToken);
        }
    }
}