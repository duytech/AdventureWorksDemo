namespace AW.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq.Expressions;

    public abstract class Repository<T> where T : class
    {
        private DbContext _entities;
        private readonly IDbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(Guid id)
        {
            return _dbset.Find(id);
        }

        public virtual T GetFirst(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll(int? pageIndex, int? pageSize)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetList(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
