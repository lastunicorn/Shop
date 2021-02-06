using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.GetPaymentDetails
{
    public class GetPaymentDetailsRequest : IRequest<Sale>
    {
        public int SaleId { get; set; }
    }
}