namespace AW.WebAPI.Common
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    public class ApplicationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception);
        }
    }
}