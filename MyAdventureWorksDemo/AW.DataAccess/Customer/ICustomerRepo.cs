namespace AW.DataAccess.Customer
{
    using Entities;
    using Common;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System;
    using AW.Common;

    public interface ICustomerRepo : IRepository<Customer>
    {
        IEnumerable<Customer> Search<TKey>(int pageIndex, int pageSize, Expression<Func<Customer, bool>> where = null, Expression<Func<Customer, TKey>> sortingExpression = null);

        IEnumerable<Customer> Search(int pageIndex, int pageSize, Expression<Func<Customer, bool>> where = null, Sorting sorting = null);
    }
}
