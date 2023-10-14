namespace Meetups.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IMeetupRepository Meetups { get; }
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollbackAsync();
    }
}