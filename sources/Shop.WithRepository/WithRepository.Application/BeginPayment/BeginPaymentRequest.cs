using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.BeginPayment
{
    public class BeginPaymentRequest : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}