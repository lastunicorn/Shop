using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.InMemory
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository productRepository;
        private IPaymentRepository paymentRepository;
        private IOrderRepository orderRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository();

                return productRepository;
            }
        }

        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository();

                return paymentRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository();

                return orderRepository;
            }
        }

        public void Complete()
        {
        }
    }
}