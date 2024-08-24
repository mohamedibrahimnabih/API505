using ECommerce.Data;
using ECommerce.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> dbSet;

        public Repository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }

            return query.ToList();
        }

        public T? GetOne(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(predicate, includeProperties).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            dbSet.UpdateRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
