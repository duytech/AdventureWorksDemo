namespace AW.DataAccess.Implementations
{
    using Common;
    using Entities;
    using Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        public CustomerRepo(IDbFactory context) : base(context)
        { }

        public virtual IEnumerable<Customer> Search(int pageIndex, int pageSize, Expression<Func<Customer, bool>> where = null)
        {
            return where != null 
                ? _dbset.Where(where).OrderBy(x => x.CustomerID).Skip(pageIndex * pageSize).Take(pageSize).ToList() 
                : _dbset.OrderBy(x => x.CustomerID).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
