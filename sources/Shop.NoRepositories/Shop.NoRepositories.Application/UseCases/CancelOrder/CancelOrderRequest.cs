using MediatR;

namespace Shop.NoRepository.Application.UseCases.CancelOrder
{
    public class CancelOrderRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}