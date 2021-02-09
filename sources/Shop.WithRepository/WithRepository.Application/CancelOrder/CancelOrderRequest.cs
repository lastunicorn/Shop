using MediatR;

namespace Shop.WithRepository.Application.CancelOrder
{
    public class CancelOrderRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}