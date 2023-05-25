using Meetups.Domain.Interfaces;
using Meetups.Infrastructure.Data.Repositories;

namespace Meetups.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Meetups = new MeetupRepository(_dbContext);
            Users = new UserRepository(_dbContext);
        }

        public IMeetupRepository Meetups { get; }
        public IUserRepository Users { get; }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}