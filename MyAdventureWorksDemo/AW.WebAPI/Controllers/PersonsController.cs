namespace AW.WebAPI.Controllers
{
    using Bussiness.Person;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class PersonsController : ApiController
    {
        private IPersonManager personManager;
        public PersonsController(IPersonManager personManager)
        {
            this.personManager = personManager;
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var r = personManager.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, r);
        }

        [HttpGet]
        public HttpResponseMessage Search()
        {
            var r = personManager.Search();
            return Request.CreateResponse(HttpStatusCode.OK, r);
        }
    }
}
