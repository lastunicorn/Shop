using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.PresentOrders
{
    public class PresentOrdersRequest : IRequest<List<Order>>
    {
    }

    internal class PresentOrdersRequestHandler : IRequestHandler<PresentOrdersRequest, List<Order>>
    {
        private readonly IUnitOfWork unitOfWork;

        public PresentOrdersRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<List<Order>> Handle(PresentOrdersRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => unitOfWork.OrderRepository.GetAllFull(), cancellationToken);
        }
    }
}