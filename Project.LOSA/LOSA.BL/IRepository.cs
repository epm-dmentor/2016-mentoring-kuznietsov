using System;
using System.Linq;
using System.Linq.Expressions;

namespace LOSA.Model
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}