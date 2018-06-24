using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnglishCenterAPI.Repository
{
    public class BaseRepository<T, K> : IBaseRepository<T>
        where T : class
        where K : DbContext
    {
        private K dataContext;
        protected IBaseUnitOfWork<K> UnitOfWork { get; set; }
        protected K DbContext
        {
            get { return dataContext ?? (dataContext = this.UnitOfWork.DbContext); }
        }
        protected DbSet<T> DbSet
        {
            get { return DbContext.Set<T>(); }
        }
        //public BaseRepository(IBaseUnitOfWork<K> unitOfWork)
        //{
        //    this.UnitOfWork = unitOfWork;
        //}
        protected virtual int GetKeyId(T model)
        {
            return 0;
        }
        protected virtual T Find(T model)
        {
            return null;
        }
        protected virtual T DoAdd(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }
        protected virtual T DoUpdate(T entity)
        {
            var currentEntry = this.Find(entity) ?? this.DbSet.Find(GetKeyId(entity));
            DbContext.Entry(currentEntry).State = EntityState.Modified;
            DbContext.Entry(currentEntry).CurrentValues.SetValues(entity);
            return currentEntry;
        }
        protected virtual void DoDelete(T entity)
        {
            var currentEntry = this.Find(entity) ?? this.DbSet.Find(GetKeyId(entity));
            if (currentEntry == null) return;
            DbSet.Remove(currentEntry);
        }
        protected virtual void DoDeleteRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
        protected virtual T DoSelect(int id)
        {
            return this.DbSet.Find(id);
        }
        protected virtual void DoAddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }
        public T Save(T entity)
        {
            T returnValue = GetKeyId(entity) != 0 ? DoUpdate(entity) : DoAdd(entity);
            return returnValue;
        }
        public void Save(IEnumerable<T> entities)
        {
            var addNews = entities.Where(x => GetKeyId(x) == 0).ToList();
            DoAddRange(addNews);
            entities.Where(x => GetKeyId(x) != 0).ToList().ForEach(x => DoUpdate(x));
        }
        public void Delete(T entity)
        {
            DoDelete(entity);
        }

        public void Delete(int id)
        {
            T entity = GetObject(id);
            Delete(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            DoDeleteRange(entities);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = DbSet.Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            return this.DbSet.AsQueryable<T>();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public T GetObject(int id)
        {
            return DoSelect(id);
        }
    }
}
