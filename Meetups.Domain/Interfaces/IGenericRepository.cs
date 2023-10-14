using Meetups.Domain.Entities;
using System.Linq.Expressions;

namespace Meetups.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Remove(T entity);
    }
}