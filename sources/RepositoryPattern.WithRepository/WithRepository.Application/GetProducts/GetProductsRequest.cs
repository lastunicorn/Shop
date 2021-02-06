using System.Collections.Generic;
using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.GetProducts
{
    public class GetProductsRequest : IRequest<List<Product>>
    {
    }
}