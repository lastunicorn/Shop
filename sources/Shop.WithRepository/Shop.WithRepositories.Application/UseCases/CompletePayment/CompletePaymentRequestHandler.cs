﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.Application.UseCases.CompletePayment
{
    internal class CompletePaymentRequestHandler : AsyncRequestHandler<CompletePaymentRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CompletePaymentRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected override async Task Handle(CompletePaymentRequest request, CancellationToken cancellationToken)
        {
            Order order = RetrieveOrder(request);
            ValidateOrderIsReadyForPayment(order);

            PerformPay(order);
            order.SetAsPayed();

            await unitOfWork.CompleteAsync(cancellationToken);
        }

        private Order RetrieveOrder(CompletePaymentRequest request)
        {
            Order order = unitOfWork.OrderRepository.GetFull(request.OrderId);

            if (order == null)
                throw new OrderMissingException(request.OrderId);

            return order;
        }

        private void PerformPay(Order order)
        {
            // Here, the application should call the bank and perform the money transfer.
            // Maybe a separate module will be created that encapsulates the details of accessing the bank's system.
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
                    throw new InvalidOrderStateException(order.Id);
            }
        }
    }
}