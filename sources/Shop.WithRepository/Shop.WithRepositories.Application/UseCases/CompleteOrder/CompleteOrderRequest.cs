using MediatR;

namespace Shop.WithRepositories.Application.UseCases.CompleteOrder
{
    public class CompleteOrderRequest : IRequest<CompleteOrderResponse>
    {
        public int OrderId { get; set; }
    }
}