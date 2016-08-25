namespace AW.WebAPI.Controllers
{
    using Bussiness.Employee;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;

    public class EmployeesController : ODataController
    {
        private IEmployeeManager employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(employeeManager.Search().ToList());
        }
    }
}
