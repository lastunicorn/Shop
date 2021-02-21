using System;
using System.Collections.Generic;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.DataAccess.EntityFramework
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        protected ShopDbContext DbContext { get; }

        public Repository(ShopDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public TEntity Get(TId id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            DbContext.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TId id)
        {
            TEntity entity = DbContext.Set<TEntity>().Find(id);

            if (entity != null)
                DbContext.Set<TEntity>().Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            DbContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}