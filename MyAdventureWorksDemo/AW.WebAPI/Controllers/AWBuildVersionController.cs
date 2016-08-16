namespace AW.WebAPI.Controllers
{
    using DataAccess.Common;
    using DataAccess.Implementations;
    using DataAccess.Interfaces;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class AWBuildVersionController : ApiController
    {
        private IAWBuildVersionRepo repo;
        public AWBuildVersionController(IAWBuildVersionRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, repo.GetAll());
        }
    }
}
