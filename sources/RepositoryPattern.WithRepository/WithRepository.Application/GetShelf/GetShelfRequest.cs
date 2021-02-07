using System.Collections.Generic;
using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.GetShelf
{
    public class GetShelfRequest : IRequest<List<ProductWithReservations>>
    {
    }
}