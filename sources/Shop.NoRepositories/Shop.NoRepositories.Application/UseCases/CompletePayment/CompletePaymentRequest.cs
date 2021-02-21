using System;
using MediatR;

namespace Shop.NoRepositories.Application.UseCases.CompletePayment
{
    public class CompletePaymentRequest : IRequest
    {
        public Guid OrderId { get; set; }
    }
}