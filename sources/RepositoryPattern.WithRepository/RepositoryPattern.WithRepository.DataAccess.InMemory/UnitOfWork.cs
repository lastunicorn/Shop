using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.InMemory
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository userRepository;
        private IProductRepository productRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository();

                return userRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository();

                return productRepository;
            }
        }

        public void Complete()
        {
        }
    }
}