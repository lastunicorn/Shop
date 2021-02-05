namespace RepositoryPattern.WithRepository.Domain.DataAccess
{
    public interface IPaymentRepository
    {
        Payment GetOneForProduct(int productId);
    }
}