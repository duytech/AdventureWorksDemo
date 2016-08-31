namespace AW.WebAPI.Common
{
    using AW.Common.Constants;
    using Microsoft.OData.Core;
    using System;

    public static class CommonFunctions
    {
        public static ODataError ExceptionToODataError(Exception ex)
        {
            return new ODataError
            {
                Message = ex.Message,
                InnerError = new ODataInnerError(ex),
                Target = ex.TargetSite.ToString(),
                ErrorCode = ErrorType.Technical.ToString()
            };
        }
    }
}