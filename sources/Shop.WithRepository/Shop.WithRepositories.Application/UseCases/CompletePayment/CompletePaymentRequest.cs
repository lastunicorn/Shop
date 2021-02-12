using MediatR;

namespace Shop.WithRepositories.Application.UseCases.CompletePayment
{
    public class CompletePaymentRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}