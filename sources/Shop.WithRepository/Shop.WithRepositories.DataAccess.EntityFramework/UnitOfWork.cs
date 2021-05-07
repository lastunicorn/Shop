using System;
using System.Threading;
using System.Threading.Tasks;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext dbContext;
        private IPaymentRepository paymentRepository;
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;

        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(dbContext);

        public IPaymentRepository PaymentRepository => paymentRepository ??= new PaymentRepository(dbContext);

        public IOrderRepository OrderRepository => orderRepository ??= new OrderRepository(dbContext);

        public UnitOfWork(ShopDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }

        public Task CompleteAsync(CancellationToken cancellationToken = default)
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}