using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.Application.UseCases.BeginOrder
{
    internal class BeginOrderRequestHandler : IRequestHandler<BeginOrderRequest, Order>
    {
        private readonly IUnitOfWork unitOfWork;

        public BeginOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Order> Handle(BeginOrderRequest request, CancellationToken cancellationToken)
        {
            Product product = RetrieveProduct(request);
            ValidateProductQuantity(product);
            Order order = CreateNewOrderFor(product);

            await unitOfWork.CompleteAsync(cancellationToken);

            return order;
        }

        private Product RetrieveProduct(BeginOrderRequest request)
        {
            Product product = unitOfWork.ProductRepository.Get(request.ProductId);

            if (product == null)
                throw new ProductMissingException(request.ProductId);

            return product;
        }

        private void ValidateProductQuantity(Product product)
        {
            List<Order> inProgressOrders = unitOfWork.OrderRepository.GetInProgressFor(product.Id).ToList();

            int availableQuantity = product.Quantity - inProgressOrders.Count;

            if (availableQuantity <= 0)
                throw new ProductQuantityException(product.Name);
        }

        private Order CreateNewOrderFor(Product product)
        {
            Order order = new Order
            {
                Date = DateTime.UtcNow,
                Product = product,
                State = OrderState.New
            };

            unitOfWork.OrderRepository.Add(order);

            return order;
        }
    }
}