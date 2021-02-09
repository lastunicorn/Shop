using System.Collections.Generic;
using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.UseCases.PresentOrders
{
    public class PresentOrdersRequest : IRequest<List<Order>>
    {
    }
}