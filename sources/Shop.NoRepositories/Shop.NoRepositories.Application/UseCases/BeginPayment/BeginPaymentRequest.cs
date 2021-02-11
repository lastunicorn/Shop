using MediatR;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.BeginPayment
{
    public class BeginPaymentRequest : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}