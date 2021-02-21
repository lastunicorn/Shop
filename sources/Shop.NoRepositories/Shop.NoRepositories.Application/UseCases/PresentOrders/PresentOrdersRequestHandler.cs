using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.DataAccess.EntityFramework;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.PresentOrders
{
    internal class PresentOrdersRequestHandler : IRequestHandler<PresentOrdersRequest, List<Order>>
    {
        private readonly ShopDbContext shopDbContext;

        public PresentOrdersRequestHandler(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        public Task<List<Order>> Handle(PresentOrdersRequest request, CancellationToken cancellationToken)
        {
            // todo: query
            return Task.Run(() => shopDbContext.Orders.GetAllFullByDate(), cancellationToken);
        }
    }
}