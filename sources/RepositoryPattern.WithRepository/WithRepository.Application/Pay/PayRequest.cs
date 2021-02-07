using MediatR;

namespace Shop.WithRepository.Application.Pay
{
    public class PayRequest : IRequest
    {
        public int SaleId { get; set; }
    }
}