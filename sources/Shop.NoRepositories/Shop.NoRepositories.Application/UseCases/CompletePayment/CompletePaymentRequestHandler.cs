using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.DataAccess.EntityFramework;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.CompletePayment
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
                Order order = RetrieveOrder(request);
                ValidateOrderIsReadyForPayment(order);

                PerformPay(order);
                SetOrderAsPayed(order);

                shopDbContext.SaveChanges();
            }, cancellationToken);
        }

        private Order RetrieveOrder(CompletePaymentRequest request)
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

        private void PerformPay(Order order)
        {
            // Here, the application should call the bank and perform the money transfer.
            // Maybe a separate module will be created that encapsulates the details of accessing the bank's system.
        }

        private void SetOrderAsPayed(Order order)
        {
            Payment payment = new Payment
            {
                Date = DateTime.UtcNow,
                Value = order.Product.Price
            };

            order.Payment = payment;
            order.State = OrderState.Payed;

            shopDbContext.Payments.Add(payment);
        }
    }
}