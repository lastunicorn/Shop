using System;
using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        protected IList<TEntity> Collection { get; }

        protected Repository(IList<TEntity> collection)
        {
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        protected abstract TId GetIdFor(TEntity entity);

        public TEntity Get(TId id)
        {
            return Collection.FirstOrDefault(x => Equals(GetIdFor(x), id));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Collection.ToList();
        }

        public void Add(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            bool entityAlreadyExists = Collection.Any(x => x == item);

            if (entityAlreadyExists)
                throw new DataAccessException("Another item with the same id already exists.");

            Collection.Add(item);
        }

        public void AddBulk(IEnumerable<TEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (TEntity item in items)
            {
                bool entityAlreadyExists = Collection.Any(x => x == item);

                if (entityAlreadyExists)
                    throw new DataAccessException("Another item with the same id already exists.");

                Collection.Add(item);
            }
        }

        public void Remove(TId id)
        {
            TEntity entity = Collection.FirstOrDefault(x => Equals(GetIdFor(x), id));

            if (entity != null)
                Collection.Remove(entity);
        }

        public void Remove(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            Collection.Remove(item);
        }

        public void RemoveBulk(IEnumerable<TEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (TEntity item in items)
                Collection.Remove(item);
        }
    }
}