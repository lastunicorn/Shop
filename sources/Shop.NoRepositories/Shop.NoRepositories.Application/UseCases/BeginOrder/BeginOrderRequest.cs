using MediatR;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.BeginOrder
{
    public class BeginOrderRequest : IRequest<Order>
    {
        public int ProductId { get; set; }
    }
}