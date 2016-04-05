using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LOSA.Model;

namespace LOSA.BL

{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private DbContext _entities;

        public DbContext Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                IQueryable<T> query = _entities.Set<T>().Where(predicate);
                return query;
            }
                return _entities.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
