namespace AW.WebAPI.Controllers
{
    using Bussiness.BuildVersion;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class BuildVersionController : ApiController
    {
        private IBuildVersionManager manager;
        public BuildVersionController(IBuildVersionManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.GetAll());
        }
    }
}
