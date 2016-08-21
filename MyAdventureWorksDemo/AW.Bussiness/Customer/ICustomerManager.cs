namespace AW.Bussiness.Customer
{
    using AW.Common.Dtos;
    using Models;
    using System.Collections.Generic;
    public interface ICustomerManager
    {
        Customer GetById(int id);

        IEnumerable<Customer> Search(int pageIndex, int pageSize, out string error, Sorting sorting = null);
    }
}
