namespace AW.DataAccess.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);

        T GetFirst(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAllWithPaging(int pageIndex, int pageSize);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetList(Expression<Func<T, bool>> where);
    }
}
