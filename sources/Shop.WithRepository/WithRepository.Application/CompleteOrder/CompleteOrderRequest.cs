using MediatR;

namespace Shop.WithRepository.Application.CompleteOrder
{
    public class CompleteOrderRequest : IRequest<CompleteOrderResponse>
    {
        public int OrderId { get; set; }
    }
}