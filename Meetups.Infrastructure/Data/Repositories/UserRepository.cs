using Meetups.Domain.Entities;
using Meetups.Domain.Interfaces;

namespace Meetups.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}