namespace AW.Bussiness.Customer
{
    using System.Collections.Generic;
    public interface ICustomerManager
    {
        Models.Customer GetById(int id);

        IEnumerable<Models.Customer> Search(int pageIndex, int pageSize);
    }
}
