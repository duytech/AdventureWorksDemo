namespace AW.Bussiness.Employee
{
    using System.Linq;
    public interface IEmployeeManager
    {
        IQueryable<Models.Employee> Search();
    }
}
