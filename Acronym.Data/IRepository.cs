using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace Acronym.Data
{
    public interface IRepository<T> : IRepository
    {
        T Find(object id);
        IQueryable<T> All();
        IQueryable<T> All(Expression<Func<T, bool>> filter);
        void Create(T entity);
        void Update(T entity);
    }

    public interface IRepository
    {
        
    }
}