namespace AW.WebAPI.Controllers
{
    #region Using
    using Bussiness.BuildVersion;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    #endregion
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
