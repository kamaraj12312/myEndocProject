using provider.DBcontext;
using provider.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Unit_of_work
{
    public class UnitOfWork
    {
        private Object lockObj = new Object();
        private Object saveLock = new Object();
        private readonly IDbContext _context;

        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IDbContext dbContext)
        {
            _context = dbContext;

        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public void Commit()
        {
            _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            lock (lockObj)
            {
                if (!_repositories.ContainsKey(type))
                {
                    var repositoryType = typeof(EfRepository<>);

                    var repositoryInstance =
                        Activator.CreateInstance(repositoryType
                                .MakeGenericType(typeof(T)), _context);

                    _repositories.Add(type, repositoryInstance);
                }
            }

            return (IRepository<T>)_repositories[type];
        }
    }
}