using System;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.Application.BuyProduct
{
    public class BuyProductHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public BuyProductHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public BuyProductResponse Execute(BuyProductRequest request)
        {
            Product product = unitOfWork.ProductRepository.Get(request.ProductId);

            if (product == null)
                throw new Exception("There is no product with the specified id.");

            Payment payment = unitOfWork.PaymentRepository.GetOneForProduct(request.ProductId);

            if (payment == null)
            {
                return new BuyProductResponse
                {
                    BuyState = BuyState.PaymentNeeded,
                    ProductId = product.Id,
                    ProductName = product.Name
                };
            }

            product.Quantity--;
            payment.IsDelivered = true;

            return new BuyProductResponse
            {
                BuyState = BuyState.Success,
                ProductId = product.Id,
                ProductName = product.Name
            };
        }
    }
}