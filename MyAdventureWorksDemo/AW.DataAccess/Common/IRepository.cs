namespace AW.DataAccess.Common
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    public interface IRepository<T> where T : class
    {
        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        T GetById(int id);

        T GetFirst(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        IQueryable<T> GetAllQueryable();

        void Save();
    }
}
