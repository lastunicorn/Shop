using System.Collections.Generic;
using MediatR;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application.UseCases.PresentShelf
{
    public class PresentShelfRequest : IRequest<List<ProductWithReservations>>
    {
    }
}