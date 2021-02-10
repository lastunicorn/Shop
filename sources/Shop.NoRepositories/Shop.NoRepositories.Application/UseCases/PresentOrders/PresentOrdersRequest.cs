using System.Collections.Generic;
using MediatR;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.PresentOrders
{
    public class PresentOrdersRequest : IRequest<List<Order>>
    {
    }
}