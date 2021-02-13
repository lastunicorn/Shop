using System;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext dbContext;
        private IPaymentRepository paymentRepository;
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(dbContext);

                return productRepository;
            }
        }

        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(dbContext);

                return paymentRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(dbContext);

                return orderRepository;
            }
        }

        public UnitOfWork(ShopDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }
    }
}