using System.Collections.Generic;
using MediatR;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application.UseCases.PresentOrders
{
    public class PresentOrdersRequest : IRequest<List<Order>>
    {
    }
}