using MediatR;

namespace Shop.WithRepository.Application.UseCases.CompletePayment
{
    public class CompletePaymentRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}