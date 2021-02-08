using System.Collections.Generic;
using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.PresentShelf
{
    public class PresentShelfRequest : IRequest<List<ProductWithReservations>>
    {
    }
}