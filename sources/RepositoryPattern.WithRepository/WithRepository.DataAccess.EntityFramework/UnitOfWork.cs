using System;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryPatternDbContext dbContext;
        private IPaymentRepository paymentRepository;
        private IProductRepository productRepository;
        private ISaleRepository saleRepository;

        public UnitOfWork(RepositoryPatternDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

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

        public ISaleRepository SaleRepository
        {
            get
            {
                if (saleRepository == null)
                    saleRepository = new SaleRepository(dbContext);

                return saleRepository;
            }
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }
    }
}