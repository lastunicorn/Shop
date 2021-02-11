using MediatR;

namespace Shop.NoRepositories.Application.UseCases.CompletePayment
{
    public class CompletePaymentRequest : IRequest
    {
        public int OrderId { get; set; }
    }
}