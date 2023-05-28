using System.Linq.Expressions;

namespace Meetups.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}