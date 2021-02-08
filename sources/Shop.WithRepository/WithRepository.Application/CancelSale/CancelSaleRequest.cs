using MediatR;

namespace Shop.WithRepository.Application.CancelSale
{
    public class CancelSaleRequest : IRequest
    {
        public int SaleId { get; set; }
    }
}