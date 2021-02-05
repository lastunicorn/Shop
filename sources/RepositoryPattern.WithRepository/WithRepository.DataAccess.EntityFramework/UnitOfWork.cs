using System;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryPatternDbContext dbContext;
        private IPaymentRepository paymentRepository;
        private IProductRepository productRepository;
        private IUserRepository userRepository;

        public UnitOfWork(RepositoryPatternDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(dbContext);

                return userRepository;
            }
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

        public void Complete()
        {
            dbContext.SaveChanges();
        }
    }
}