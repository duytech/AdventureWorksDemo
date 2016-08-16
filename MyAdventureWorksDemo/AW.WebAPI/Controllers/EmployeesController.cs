namespace AW.WebAPI.Controllers
{
    using System.Net.Http;
    using System.Web.Http;
    using DataAccess.Implementations;
    using DataAccess.Common;
    using System.Net;

    public class EmployeesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var repo = new EmployeeRepo(new AWDbFactory());
            var result = repo.GetFirst(x => x.BusinessEntityID == id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage Search()
        {
            var repo = new EmployeeRepo(new AWDbFactory());
            var result = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
