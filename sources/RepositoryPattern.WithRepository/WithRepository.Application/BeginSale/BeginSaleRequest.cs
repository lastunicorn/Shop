using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.BeginSale
{
    public class BeginSaleRequest : IRequest<Sale>
    {
        public int ProductId { get; set; }
    }
}