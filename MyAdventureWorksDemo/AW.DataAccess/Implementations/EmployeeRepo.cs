namespace AW.DataAccess.Implementations
{
    using Common;
    using Entities;
    using Interfaces;
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(IAWDbFactory context) : base(context) { }
    }
}
