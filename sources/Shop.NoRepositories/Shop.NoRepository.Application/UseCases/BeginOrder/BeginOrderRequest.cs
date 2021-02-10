using MediatR;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.BeginOrder
{
    public class BeginOrderRequest : IRequest<Order>
    {
        public int ProductId { get; set; }
    }
}