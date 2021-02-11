using MediatR;

namespace Shop.NoRepositories.Application.UseCases.CompleteOrder
{
    public class CompleteOrderRequest : IRequest<CompleteOrderResponse>
    {
        public int OrderId { get; set; }
    }
}