using MediatR;

namespace Shop.WithRepository.Application.CompleteSale
{
    public class CompleteSaleRequest : IRequest<CompleteSaleResponse>
    {
        public int SaleId { get; set; }
    }
}