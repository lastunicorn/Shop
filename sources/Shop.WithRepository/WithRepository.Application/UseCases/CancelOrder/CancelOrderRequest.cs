using MediatR;

namespace Shop.WithRepository.Application.UseCases.CancelOrder
{
    public class CancelOrderRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}