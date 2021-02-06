using MediatR;
using RepositoryPattern.WithRepository.Domain;

namespace RepositoryPattern.WithRepository.Application.CreateSale
{
    public class CreateSaleRequest : IRequest<Sale>
    {
        public int ProductId { get; set; }
    }
}