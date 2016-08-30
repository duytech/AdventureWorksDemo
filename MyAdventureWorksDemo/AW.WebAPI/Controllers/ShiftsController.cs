namespace AW.WebAPI.Controllers
{
    using Bussiness.Shift;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;
    public class ShiftsController : ODataController
    {
        private IShiftManager shiftManager;

        public ShiftsController(IShiftManager shiftManager)
        {
            this.shiftManager = shiftManager;
        }

        [HttpGet]
        [EnableQuery(PageSize = 10)]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, shiftManager.Search().ToList());
        }
    }
}
