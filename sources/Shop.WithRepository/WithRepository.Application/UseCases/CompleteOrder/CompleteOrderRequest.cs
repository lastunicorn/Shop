using MediatR;

namespace Shop.WithRepository.Application.UseCases.CompleteOrder
{
    public class CompleteOrderRequest : IRequest<CompleteOrderResponse>
    {
        public int OrderId { get; set; }
    }
}