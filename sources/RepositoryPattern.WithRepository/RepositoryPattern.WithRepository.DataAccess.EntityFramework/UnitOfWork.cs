using System;
using System.Collections.Generic;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryPatternDbContext dbContext;
        private IUserRepository userRepository;
        private IProductRepository productRepository;

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

        public UnitOfWork(RepositoryPatternDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }
    }
}