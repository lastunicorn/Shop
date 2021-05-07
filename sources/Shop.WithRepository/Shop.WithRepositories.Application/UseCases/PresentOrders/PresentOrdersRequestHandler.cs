using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.Application.UseCases.PresentOrders
{
    internal class PresentOrdersRequestHandler : IRequestHandler<PresentOrdersRequest, List<Order>>
    {
        private readonly IUnitOfWork unitOfWork;

        public PresentOrdersRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<List<Order>> Handle(PresentOrdersRequest request, CancellationToken cancellationToken)
        {
            List<Order> orders = unitOfWork.OrderRepository.GetAllFullByDate();
            return Task.FromResult(orders);
        }
    }
}