using System;
using MediatR;

namespace Shop.WithRepositories.Application.UseCases.CompletePayment
{
    public class CompletePaymentRequest : IRequest
    {
        public Guid OrderId { get; set; }
    }
}