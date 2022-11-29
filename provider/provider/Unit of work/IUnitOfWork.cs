using provider.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Unit_of_work
{
    public interface IUnitOfWork
    {
        void Dispose();
        int Save();
        void Dispose(bool disposing);
        IRepository<T> Repository<T>() where T : class;
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}