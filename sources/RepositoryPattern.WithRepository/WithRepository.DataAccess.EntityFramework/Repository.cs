using System;
using System.Collections.Generic;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.EntityFramework
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected RepositoryPatternDbContext DbContext { get; }

        public Repository(RepositoryPatternDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public T Get(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbContext.Set<T>().Add(entity);
        }

        public void AddBulk(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            DbContext.Set<T>().AddRange(entities);
        }

        public void Remove(int id)
        {
            T entity = DbContext.Set<T>().Find(id);

            if (entity != null)
                DbContext.Set<T>().Remove(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbContext.Set<T>().Remove(entity);
        }

        public void RemoveBulk(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            DbContext.Set<T>().RemoveRange(entities);
        }
    }
}