using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;

namespace provider.DBcontext
{
    public interface IDbContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        DbEntityEntry Entry(object o);
        void Dispose();

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
           where TEntity : class, new();

        int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters);

        int SetUserID(string userId);

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters);

        DataTable ExecuteSqlQuery(string commandText, params object[] parameters);


        void BeginTransaction();

        void Commit();


        void Rollback();

    }
}