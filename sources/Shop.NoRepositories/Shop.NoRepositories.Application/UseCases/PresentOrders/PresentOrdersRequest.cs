using System.Collections.Generic;
using MediatR;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.PresentOrders
{
    public class PresentOrdersRequest : IRequest<List<Order>>
    {
    }
}