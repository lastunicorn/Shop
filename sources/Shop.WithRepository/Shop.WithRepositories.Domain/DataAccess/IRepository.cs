using System.Collections.Generic;

namespace Shop.WithRepositories.Domain.DataAccess
{
    public interface IRepository<TEntity, in TId>
        where TEntity : class
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TId id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}