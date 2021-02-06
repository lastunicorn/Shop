using System;
using System.Collections.Generic;
using System.Linq;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.DataAccess.InMemory
{
    public class Repository<T>
        where T : class
    {
        protected List<T> Collection { get; }

        public Repository(List<T> collection)
        {
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.ToList();
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            bool entityAlreadyExists = Collection.Any(x => x == item);

            if (entityAlreadyExists)
                throw new DataAccessException("Another item with the same id already exists.");

            Collection.Add(item);
        }

        public void AddBulk(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (T item in items)
            {
                bool entityAlreadyExists = Collection.Any(x => x == item);

                if (entityAlreadyExists)
                    throw new DataAccessException("Another item with the same id already exists.");

                Collection.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            Collection.Remove(item);
        }

        public void RemoveBulk(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (T item in items)
                Collection.Remove(item);
        }
    }
}