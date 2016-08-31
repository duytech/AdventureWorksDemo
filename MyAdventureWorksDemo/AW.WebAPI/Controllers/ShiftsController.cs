namespace AW.WebAPI.Controllers
{
    using Attributes;
    using AW.Common.Constants;
    using Bussiness.Shift;
    using Microsoft.OData.Core;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Extensions;
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

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage GetShift(int key)
        {
            var result = shiftManager.GetById(key);

            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Message.Common.NotExist, nameof(Models.Shift), key));
        }

        [HttpPost]
        [ValidateModel]
        public HttpResponseMessage Post(Models.Shift shift)
        {
            string error = string.Empty;
            var shiftCreated = shiftManager.Save(shift, out error);
            if (!string.IsNullOrEmpty(error))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ODataError { Message = error, ErrorCode = ErrorType.Business.ToString()});

            return Request.CreateResponse(HttpStatusCode.Created, shiftCreated);
        }
    }
}
