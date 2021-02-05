using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.InMemory
{
    public class ProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            return InMemoryDatabase.Products.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return InMemoryDatabase.Products;
        }

        public void Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            bool entityAlreadyExists = InMemoryDatabase.Products.Any(x => x.Id == product.Id);

            if (entityAlreadyExists)
                throw new DataAccessException("Another product with the same id already exists.");

            InMemoryDatabase.Products.Add(product);
        }

        public void AddBulk(IEnumerable<Product> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            foreach (Product product in entities)
            {
                bool entityAlreadyExists = InMemoryDatabase.Products.Any(x => x.Id == product.Id);

                if (entityAlreadyExists)
                    throw new DataAccessException("Another product with the same id already exists.");

                InMemoryDatabase.Products.Add(product);
            }
        }

        public void Remove(int id)
        {
            InMemoryDatabase.Products.RemoveAll(x => x.Id == id);
        }

        public void Remove(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            InMemoryDatabase.Products.Remove(product);
        }

        public void RemoveBulk(IEnumerable<Product> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            foreach (Product product in entities)
                InMemoryDatabase.Products.Remove(product);
        }
    }
}