using MediatR;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application.UseCases.BeginPayment
{
    public class BeginPaymentRequest : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}