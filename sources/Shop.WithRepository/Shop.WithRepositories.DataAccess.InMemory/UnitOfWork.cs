using System.Threading;
using System.Threading.Tasks;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.InMemory
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository productRepository;
        private IPaymentRepository paymentRepository;
        private IOrderRepository orderRepository;

        public IProductRepository ProductRepository => productRepository ??= new ProductRepository();

        public IPaymentRepository PaymentRepository => paymentRepository ??= new PaymentRepository();

        public IOrderRepository OrderRepository => orderRepository ??= new OrderRepository();

        public void Complete()
        {
        }

        public Task CompleteAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}