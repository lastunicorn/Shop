using System.Collections.Generic;
using MediatR;
using RepositoryPattern.WithRepository.Domain;

namespace RepositoryPattern.WithRepository.Application.GetProducts
{
    public class GetProductsRequest : IRequest<List<Product>>
    {
    }
}