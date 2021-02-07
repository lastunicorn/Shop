using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.GetShelf
{
    internal class GetShelfRequestHandler : IRequestHandler<GetShelfRequest, List<ProductWithReservations>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetShelfRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<List<ProductWithReservations>> Handle(GetShelfRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => unitOfWork.ProductRepository.GetAvailable().ToList(), cancellationToken);
        }
    }
}