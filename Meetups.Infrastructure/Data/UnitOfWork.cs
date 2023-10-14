using Meetups.Domain.Interfaces;
using Meetups.Infrastructure.Data.Repositories;
 
namespace Meetups.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Accounts = new AccountRepository(_dbContext);
            Meetups = new MeetupRepository(_dbContext);
        }

        public IAccountRepository Accounts { get; }
        public IMeetupRepository Meetups { get; }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RollbackAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}