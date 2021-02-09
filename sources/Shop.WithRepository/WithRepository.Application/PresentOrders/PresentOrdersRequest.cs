using System.Collections.Generic;
using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.PresentOrders
{
    public class PresentOrdersRequest : IRequest<List<Order>>
    {
    }
}