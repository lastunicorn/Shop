using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository productRepository;
        private IPaymentRepository paymentRepository;
        private ISaleRepository saleRepository;

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

        public ISaleRepository SaleRepository
        {
            get
            {
                if (saleRepository == null)
                    saleRepository = new SaleRepository();

                return saleRepository;
            }
        }

        public void Complete()
        {
        }
    }
}