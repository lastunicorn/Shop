namespace RepositoryPattern.WithRepository.Domain.DataAccess
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IProductRepository ProductRepository { get; }
        
        IPaymentRepository PaymentRepository { get; }

        void Complete();
    }
}