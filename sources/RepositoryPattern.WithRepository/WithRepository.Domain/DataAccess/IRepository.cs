using System.Collections.Generic;

namespace RepositoryPattern.WithRepository.Domain.DataAccess
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T entity);
        void AddBulk(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveBulk(IEnumerable<T> entities);
    }
}