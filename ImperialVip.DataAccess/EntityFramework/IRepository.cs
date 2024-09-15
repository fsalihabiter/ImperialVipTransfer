using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.EntityFramework
{
    public interface IRepository<T> where T : class
    {

        T Get(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);
        T Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void DeleteById(int id);
        void Delete(T entity);
        void Update(T entity);

    }
}
