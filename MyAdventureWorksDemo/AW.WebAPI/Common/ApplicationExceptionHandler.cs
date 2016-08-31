namespace AW.WebAPI.Common
{
    using System.Web.Http.ExceptionHandling;
    using System.Net.Http;
    using System.Net;
    using Microsoft.OData.Core;

    public class ApplicationExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(context.Exception.Message)
            };

            context.Result = new CustomHttpActionResult(context.Request, result);
        }
    }
}