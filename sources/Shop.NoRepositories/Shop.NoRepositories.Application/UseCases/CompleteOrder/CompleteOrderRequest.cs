using System;
using MediatR;

namespace Shop.NoRepositories.Application.UseCases.CompleteOrder
{
    public class CompleteOrderRequest : IRequest<CompleteOrderResponse>
    {
        public Guid OrderId { get; set; }
    }
}