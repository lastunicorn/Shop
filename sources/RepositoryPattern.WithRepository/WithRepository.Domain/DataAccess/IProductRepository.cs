namespace Shop.WithRepository.Domain.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(int id);

        void Remove(int id);
    }
}