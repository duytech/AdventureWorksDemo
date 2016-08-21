namespace AW.DataAccess.Customer
{
    #region Using
    using AW.Common;
    using Common;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using AW.Common.Extensions;
    using AW.Common.Dtos;
    using AW.Common.Utils;
    #endregion

    public class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        public CustomerRepo(IDbFactory context) : base(context)
        { }

        public virtual IEnumerable<Customer> Search<TKey>(int pageIndex, int pageSize, Expression<Func<Customer, bool>> where = null, Expression<Func<Customer, TKey>> sortingExpression = null)
        {
            var result = _dbset.AsQueryable();
            if (where != null)
                result = result.Where(where);

            result = sortingExpression != null ? result.OrderBy(sortingExpression) : result.OrderBy(x => x.CustomerID);

            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }

        public virtual IEnumerable<Customer> Search(int pageIndex, int pageSize, Expression<Func<Customer, bool>> where = null, Sorting sorting = null)
        {
            var result = _dbset.AsQueryable();
            if (where != null)
                result = result.Where(where);

            result = sorting != null ? result.OrderBy(sorting.PropertyName, sorting.Direction) : result.OrderBy(x => x.CustomerID);

            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }
    }
}
