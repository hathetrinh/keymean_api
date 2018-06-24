using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnglishCenterAPI.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Save(T entity);
        void Save(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(int id);
        void Delete(IEnumerable<T> entities);
        T GetObject(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
    }
}
