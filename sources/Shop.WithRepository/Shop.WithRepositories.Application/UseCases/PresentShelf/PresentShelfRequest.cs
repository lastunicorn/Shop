using System.Collections.Generic;
using MediatR;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application.UseCases.PresentShelf
{
    public class PresentShelfRequest : IRequest<List<ProductWithReservations>>
    {
    }
}