using System.Linq.Expressions;

namespace ECommerce.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        IEnumerable<T> Get(Expression<Func<T, bool>>? predicate, params Expression<Func<T, Object>>[] includeProperties);

        T? GetOne(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includeProperties);
    }
}
