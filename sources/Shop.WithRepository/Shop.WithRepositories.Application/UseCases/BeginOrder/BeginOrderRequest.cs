using MediatR;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application.UseCases.BeginOrder
{
    public class BeginOrderRequest : IRequest<Order>
    {
        public int ProductId { get; set; }
    }
}