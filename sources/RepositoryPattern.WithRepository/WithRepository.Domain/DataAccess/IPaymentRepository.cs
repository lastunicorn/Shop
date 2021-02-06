namespace RepositoryPattern.WithRepository.Domain.DataAccess
{
    public interface IPaymentRepository
    {
        Payment Get(int id);

        Payment GetOneForProduct(int productId);

        void Remove(int id);
    }
}