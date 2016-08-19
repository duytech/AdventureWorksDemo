namespace AW.WebAPI.Controllers
{
    using Bussiness.Customer;
    using Common;
    using Common.Constants;
    using Common.Utils;
    using Models;
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
        public HttpResponseMessage Search(string sorting = null, int pageIndex = 1, int pageSize = 100)
        {
            var sortParsed = CommonUtils.ParseSorting(sorting);
            if (sortParsed == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Message.Common.SortingInvalid);

            string error = string.Empty;
            var result = customerManager.Search(pageIndex, pageSize, out error, sortParsed);
            if (!string.IsNullOrEmpty(error))
                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, error);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


    }
}
