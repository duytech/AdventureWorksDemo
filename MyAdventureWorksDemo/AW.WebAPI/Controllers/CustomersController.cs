namespace AW.WebAPI.Controllers
{
    using Bussiness.Customer;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class CustomersController : ApiController
    {
        private ICustomerManager customerManager;
        public CustomersController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var result = customerManager.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage Search(int pageIndex = 1, int pageSize = 100)
        {
            var result = customerManager.Search(pageIndex, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
