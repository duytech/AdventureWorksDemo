namespace AW.WebAPI.Controllers
{
    using Attributes;
    using Bussiness.Employee;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;

    public class EmployeesController : ODataController
    {
        private IEmployeeManager employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        [HttpGet]
        [EnableQuery(PageSize = 10)]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, employeeManager.Search().ToList());
        }

        [HttpPost]
        [ValidateModel]
        public HttpResponseMessage Post(Models.Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
