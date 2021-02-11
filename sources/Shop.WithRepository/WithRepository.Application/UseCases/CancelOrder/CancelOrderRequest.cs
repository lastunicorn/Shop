using MediatR;

namespace Shop.WithRepositories.Application.UseCases.CancelOrder
{
    public class CancelOrderRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}