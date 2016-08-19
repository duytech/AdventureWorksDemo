namespace AW.Bussiness.Customer
{
    using AW.Common;
    using Models;
    using System.Collections.Generic;
    public interface ICustomerManager
    {
        Models.Customer GetById(int id);

        IEnumerable<Models.Customer> Search(int pageIndex, int pageSize, out string error, Sorting sorting = null);
    }
}
