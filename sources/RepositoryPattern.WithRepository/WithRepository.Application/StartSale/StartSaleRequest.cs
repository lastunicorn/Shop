using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.StartSale
{
    public class StartSaleRequest : IRequest<Sale>
    {
        public int ProductId { get; set; }
    }
}