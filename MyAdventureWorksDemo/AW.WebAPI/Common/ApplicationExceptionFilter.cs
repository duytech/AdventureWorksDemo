﻿namespace AW.WebAPI.Common
{
    using Microsoft.OData.Core;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using System.Web.OData.Extensions;
    public class ApplicationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var exception = actionExecutedContext.Exception;
            if (controllerName == "Shifts" || controllerName == "Employees")
            {
                
                // OData has its own error response
                // Need to use System.Web.OData.Extensions.HttpRequestMessageExtensions.CreateErrorResponse method
                ODataInnerError innerError = new ODataInnerError(exception);
                ODataError error = new ODataError
                {
                    Message = exception.Message,
                    ErrorCode = "InternalServerError"
                };
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
            }
            else
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception);
            }
        }
    }
}