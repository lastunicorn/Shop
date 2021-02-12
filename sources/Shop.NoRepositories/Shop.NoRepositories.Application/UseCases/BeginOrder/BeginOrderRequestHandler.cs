using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.NoRepositories.DataAccess.EntityFramework;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.BeginOrder
{
    internal class BeginOrderRequestHandler : IRequestHandler<BeginOrderRequest, Order>
    {
        private readonly ShopDbContext shopDbContext;

        public BeginOrderRequestHandler(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        public Task<Order> Handle(BeginOrderRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                // todo: query
                Product product = shopDbContext.Products.GetById(request.ProductId);

                if (product == null)
                    throw new ProductMissingException(request.ProductId);

                // todo: query
                List<Order> inProgressOrders = shopDbContext.Orders.GetInProgress(request.ProductId);

                int availableQuantity = product.Quantity - inProgressOrders.Count;

                if (availableQuantity <= 0)
                    throw new ProductQuantityException(product.Name);

                Order order = new Order
                {
                    Date = DateTime.UtcNow,
                    Product = product,
                    State = OrderState.New
                };

                shopDbContext.Orders.Add(order);

                shopDbContext.SaveChanges();

                return order;
            }, cancellationToken);
        }
    }
}