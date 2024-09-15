using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.EntityFramework
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ImperialDatabaseContext _context;
        public Repository(ImperialDatabaseContext context)
        {
            _context = context;
        }
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            T entity = _context.Set<T>().Find(id);
            Delete(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().AddOrUpdate(entity);
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return query;
        }
    }
}
