using MediatR;

namespace Shop.NoRepository.Application.UseCases.CompletePayment
{
    public class CompletePaymentRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}