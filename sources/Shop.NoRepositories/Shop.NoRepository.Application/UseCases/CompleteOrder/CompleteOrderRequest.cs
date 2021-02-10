using MediatR;

namespace Shop.NoRepository.Application.UseCases.CompleteOrder
{
    public class CompleteOrderRequest : IRequest<CompleteOrderResponse>
    {
        public int OrderId { get; set; }
    }
}