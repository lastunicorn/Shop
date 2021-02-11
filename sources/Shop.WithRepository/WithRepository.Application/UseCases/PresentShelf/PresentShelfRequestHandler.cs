using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.Application.UseCases.PresentShelf
{
    internal class PresentShelfRequestHandler : IRequestHandler<PresentShelfRequest, List<ProductWithReservations>>
    {
        private readonly IUnitOfWork unitOfWork;

        public PresentShelfRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<List<ProductWithReservations>> Handle(PresentShelfRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => unitOfWork.ProductRepository.GetAvailable().ToList(), cancellationToken);
        }
    }
}