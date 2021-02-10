using MediatR;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.BeginPayment
{
    public class BeginPaymentRequest : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}