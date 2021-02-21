using System;
using MediatR;

namespace Shop.WithRepositories.Application.UseCases.CompleteOrder
{
    public class CompleteOrderRequest : IRequest<CompleteOrderResponse>
    {
        public Guid OrderId { get; set; }
    }
}