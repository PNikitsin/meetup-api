namespace Meetups.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IMeetupRepository Meetups { get; }
        IUserRepository Users { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}