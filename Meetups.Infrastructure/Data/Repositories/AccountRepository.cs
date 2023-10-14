using Meetups.Domain.Entities;
using Meetups.Domain.Interfaces;

namespace Meetups.Infrastructure.Data.Repositories
{
    internal class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}