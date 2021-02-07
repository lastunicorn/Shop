namespace Shop.WithRepository.Domain.DataAccess
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        IPaymentRepository PaymentRepository { get; }

        ISaleRepository SaleRepository { get; }

        void Complete();
    }
}