using System;
using System.Collections.Generic;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly RepositoryPatternDbContext dbContext;

        public Repository(RepositoryPatternDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            dbContext.Set<T>().Add(entity);
        }

        public void AddBulk(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            dbContext.Set<T>().AddRange(entities);
        }

        public void Remove(int id)
        {
            T entity = dbContext.Set<T>().Find(id);

            if (entity != null)
                dbContext.Set<T>().Remove(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            dbContext.Set<T>().Remove(entity);
        }

        public void RemoveBulk(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            dbContext.Set<T>().RemoveRange(entities);
        }
    }
}