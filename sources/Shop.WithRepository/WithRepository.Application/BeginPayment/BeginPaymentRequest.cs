using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.BeginPayment
{
    public class BeginPaymentRequest : IRequest<Sale>
    {
        public int SaleId { get; set; }
    }
}