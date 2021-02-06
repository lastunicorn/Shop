using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.CreateSale
{
    public class CreateSaleRequest : IRequest<Sale>
    {
        public int ProductId { get; set; }
    }
}