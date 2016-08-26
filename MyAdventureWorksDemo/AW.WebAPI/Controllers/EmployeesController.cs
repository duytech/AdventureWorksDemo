namespace AW.WebAPI.Controllers
{
    using Bussiness.Employee;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.OData;

    public class EmployeesController : ODataController
    {
        private IEmployeeManager employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        [EnableQuery]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, employeeManager.Search().ToList());
        }
    }
}
