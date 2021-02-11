using MediatR;

namespace Shop.NoRepositories.Application.UseCases.CancelOrder
{
    public class CancelOrderRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}