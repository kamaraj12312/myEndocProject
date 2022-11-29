using provider.DBcontext;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace provider.Repository
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        public static List<string> InvalidJsonElements;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public virtual int Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Type type = entity.GetType();
                PropertyInfo info = type.GetProperty("CreatedDate");
                if (info != null)
                {
                    info.SetValue(entity, DateTime.UtcNow, null);
                }
                this.Entities.Add(entity);
                string modelName = entity.GetType().Name;
                if (modelName.Trim().ToLower() == "auditreport")
                {
                    this._context.SetUserID(GetPropertyValue(entity, "UserName"));
                }
                else if (modelName.Trim().ToLower() == "useractivation")
                {
                    this._context.SetUserID(GetPropertyValue(entity, "TransactionBy"));
                }
                else
                {
                    this._context.SetUserID(GetPropertyValue(entity, "CreatedBy"));
                }
                RemoveWhiteSpace(entity);
                return this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                return -1;
            }
        }

        public virtual int Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Type type = entity.GetType();
                PropertyInfo info = type.GetProperty("ModifiedDate");

                if (info != null)
                {
                    info.SetValue(entity, DateTime.UtcNow, null);

                }
                RemoveWhiteSpace(entity);

                string modelName = entity.GetType().Name;
                if (modelName.ToUpper().Trim().IndexOf("USERACTIVATION") > -1)
                {
                    this._context.SetUserID(GetPropertyValue(entity, "TransactionBy"));
                }
                else
                {
                    this._context.SetUserID(GetPropertyValue(entity, "ModifiedBy"));
                }

                return this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                //throw fail;
                return -1;
            }
        }

        private static void RemoveWhiteSpace(T entity)
        {
            foreach (System.Reflection.PropertyInfo pi in entity.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    if (pi.GetValue(entity) != null)
                    {
                        string originalValue = pi.GetValue(entity).ToString();

                        if (!string.IsNullOrEmpty(originalValue))
                        {
                            originalValue = originalValue.Trim();
                            pi.SetValue(entity, originalValue);
                        }
                    }
                }
            }
        }
        private string GetPropertyValue(T TEntity, string propertyName)
        {
            object value = "";
            Type type = TEntity.GetType();
            PropertyInfo info = type.GetProperty(propertyName);
            if (info!=null)
                value = info.GetValue(TEntity, null);

            return value.ToString();
        }


        public virtual int Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Attach(entity);
                this._entities.Remove(entity);
                return this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                //throw fail;
                return -1;
            }
        }

        public virtual IList<T> DeserializeToList<T>(string jsonString)
        {
            InvalidJsonElements = null;
            var array = JArray.Parse(jsonString);
            IList<T> objectsList = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    // CorrectElements
                    objectsList.Add(item.ToObject<T>());
                }
                catch (Exception ex)
                {
                    InvalidJsonElements = InvalidJsonElements ?? new List<string>();
                    InvalidJsonElements.Add(item.ToString());
                    string errorMessage = ex.Message;
                }
            }

            return objectsList;
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
        public virtual int Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.Entities.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                this.Entities.Remove(obj);

            return this._context.SaveChanges();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this.Entities.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return this.Entities.Where(where).FirstOrDefault<T>();
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}