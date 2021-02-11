using System.Collections.Generic;
using MediatR;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.PresentShelf
{
    public class PresentShelfRequest : IRequest<List<ProductWithReservations>>
    {
    }
}