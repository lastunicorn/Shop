using System;
using MediatR;

namespace Shop.WithRepositories.Application.UseCases.CancelOrder
{
    public class CancelOrderRequest : IRequest
    {
        public Guid OrderId { get; set; }
    }
}