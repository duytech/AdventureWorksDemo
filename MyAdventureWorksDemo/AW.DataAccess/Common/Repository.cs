namespace AW.DataAccess.Common
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    #endregion

    public abstract class Repository<T> where T : class
    {
        protected IDbFactory _entities;
        protected readonly IDbSet<T> _dbset;

        public Repository(IDbFactory context)
        {
            _entities = context;
            _dbset = context.GetDb().Set<T>();
        }

        public virtual T Create(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _entities.GetDb().Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T entityToDelete = _dbset.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (_entities.GetDb().Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var query = _dbset.Where(where);

            string selectSql = query.ToString();
            string deleteSql = "DELETE [Extent1] " + selectSql.Substring(selectSql.IndexOf("FROM"));

            var internalQuery = query.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(field => field.Name == "_internalQuery").Select(field => field.GetValue(query)).First();
            var objectQuery = internalQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(field => field.Name == "_objectQuery").Select(field => field.GetValue(internalQuery)).First() as ObjectQuery;
            var parameters = objectQuery.Parameters.Select(p => new SqlParameter(p.Name, p.Value)).ToArray();

            _entities.GetDb().Database.ExecuteSqlCommand(deleteSql, parameters);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public virtual T GetFirst(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).First();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public virtual void Save()
        {
            _entities.GetDb().SaveChanges();
        }
    }
}
