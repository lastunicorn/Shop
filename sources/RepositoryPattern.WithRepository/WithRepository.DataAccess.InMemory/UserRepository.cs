using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.InMemory
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            return InMemoryDatabase.Users.Find(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return InMemoryDatabase.Users;
        }

        public void Add(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            bool entityAlreadyExists = InMemoryDatabase.Users.Any(x => x.Id == user.Id);

            if (entityAlreadyExists)
                throw new DataAccessException("Another user with the same id already exists.");

            InMemoryDatabase.Users.Add(user);
        }

        public void AddBulk(IEnumerable<User> users)
        {
            if (users == null) throw new ArgumentNullException(nameof(users));

            foreach (User user in users)
            {
                bool entityAlreadyExists = InMemoryDatabase.Users.Any(x => x.Id == user.Id);

                if (entityAlreadyExists)
                    throw new DataAccessException("Another user with the same id already exists.");

                InMemoryDatabase.Users.Add(user);
            }
        }

        public void Remove(int id)
        {
            InMemoryDatabase.Users.RemoveAll(x => x.Id == id);
        }

        public void Remove(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            InMemoryDatabase.Users.Remove(user);
        }

        public void RemoveBulk(IEnumerable<User> users)
        {
            if (users == null) throw new ArgumentNullException(nameof(users));

            foreach (User user in users)
                InMemoryDatabase.Users.Remove(user);
        }
    }
}