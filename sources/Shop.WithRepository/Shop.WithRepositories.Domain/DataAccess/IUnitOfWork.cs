using System.Threading;
using System.Threading.Tasks;

namespace Shop.WithRepositories.Domain.DataAccess
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        IPaymentRepository PaymentRepository { get; }

        IOrderRepository OrderRepository { get; }

        void Complete();

        Task CompleteAsync(CancellationToken cancellationToken = default);
    }
}