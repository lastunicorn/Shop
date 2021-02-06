namespace Shop.WithRepository.Domain.DataAccess
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment Get(int id);

        void Remove(int id);
    }
}