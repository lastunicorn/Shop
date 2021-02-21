using System;
using MediatR;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application.UseCases.BeginPayment
{
    public class BeginPaymentRequest : IRequest<Order>
    {
        public Guid OrderId { get; set; }
    }
}