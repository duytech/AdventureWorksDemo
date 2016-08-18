namespace AW.DataAccess.Customer
{
    using Entities;
    using Common;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System;

    public interface ICustomerRepo : IRepository<Customer>
    {
        IEnumerable<Customer> Search(int pageIndex, int pageSize, Expression<Func<Customer, bool>> where = null);
    }
}
