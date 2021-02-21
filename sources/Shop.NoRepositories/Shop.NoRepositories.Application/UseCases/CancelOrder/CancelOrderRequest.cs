using System;
using MediatR;

namespace Shop.NoRepositories.Application.UseCases.CancelOrder
{
    public class CancelOrderRequest : IRequest
    {
        public Guid OrderId { get; set; }
    }
}