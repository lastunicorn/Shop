using RepositoryPattern.WithRepository.Domain;
using RepositoryPattern.WithRepository.Domain.DataAccess;

namespace RepositoryPattern.WithRepository.DataAccess.EntityFramework
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RepositoryPatternDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}