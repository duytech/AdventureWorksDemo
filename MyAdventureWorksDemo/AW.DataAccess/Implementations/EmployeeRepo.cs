namespace AW.DataAccess.Implementations
{
    using Common;
    using Entities;
    using Interfaces;
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(IDbFactory context) : base(context) { }
    }
}
