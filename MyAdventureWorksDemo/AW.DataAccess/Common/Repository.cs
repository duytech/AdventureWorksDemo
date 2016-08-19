namespace AW.DataAccess.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public abstract class Repository<T> where T : class
    {
        protected IDbFactory _entities;
        protected readonly IDbSet<T> _dbset;

        public Repository(IDbFactory context)
        {
            //context.GetDb().Configuration.ProxyCreationEnabled = false;
            _entities = context;
            _dbset = context.GetDb().Set<T>();
        }

        public virtual void Create(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
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

        public virtual T GetById(int id)
        {
            var result = _dbset.Find(id);
            return result;
        }

        public virtual T GetFirst(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).First();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }
    }
}
