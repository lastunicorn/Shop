using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.BeginOrder
{
    internal class BeginOrderRequestHandler : IRequestHandler<BeginOrderRequest, Order>
    {
        private readonly IUnitOfWork unitOfWork;

        public BeginOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<Order> Handle(BeginOrderRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Product product = unitOfWork.ProductRepository.Get(request.ProductId);

                if (product == null)
                    throw new ProductMissingException(request.ProductId);

                List<Order> inProgressOrders = unitOfWork.OrderRepository.GetInProgress(product.Id).ToList();

                int availableQuantity = product.Quantity - inProgressOrders.Count;

                if (availableQuantity <= 0)
                    throw new ProductQuantityException(product.Name);

                Order order = new Order
                {
                    Date = DateTime.UtcNow,
                    Product = product,
                    State = OrderState.New
                };

                unitOfWork.OrderRepository.Add(order);

                unitOfWork.Complete();

                return order;
            }, cancellationToken);
        }
    }
}