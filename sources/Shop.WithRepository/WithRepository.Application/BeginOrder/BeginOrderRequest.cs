using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.BeginOrder
{
    public class BeginOrderRequest : IRequest<Order>
    {
        public int ProductId { get; set; }
    }
}