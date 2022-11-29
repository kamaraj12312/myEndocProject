using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace provider.Repository
{
    public partial interface IRepository<T> where T : class
    {
        T GetById(object id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Delete(Expression<Func<T, bool>> where);
        IQueryable<T> Table { get; }
        IList<T> DeserializeToList<T>(string jsonString);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

    }
}