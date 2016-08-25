namespace AW.DataAccess.Employee
{
    using AW.DataAccess.Common;
    public class EmployeeRepo : Repository<Entities.Employee>, IEmployeeRepo
    {
        public EmployeeRepo(IDbFactory context) : base(context) { }
    }
}
