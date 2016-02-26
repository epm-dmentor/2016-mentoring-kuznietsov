using System;
using System.Linq;
using System.Linq.Expressions;

namespace LOSA.Model
{
    public interface IRepository<T>
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}