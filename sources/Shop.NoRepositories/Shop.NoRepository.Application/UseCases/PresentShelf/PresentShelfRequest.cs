using System.Collections.Generic;
using MediatR;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.PresentShelf
{
    public class PresentShelfRequest : IRequest<List<ProductWithReservations>>
    {
    }
}