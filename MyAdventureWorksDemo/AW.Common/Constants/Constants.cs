namespace AW.Common.Constants
{
    public struct Message
    {
        public struct Common
        {
            public const string Successful = "The operation is successful.";
            public const string NotExist = "The {0} '{1}' does not exist in system.";
            public const string RequestInvalid = "The request message is invalid.";
            public const string ExceptionOccurs = "An unexpected error occurred during process your request. Please contact your administrator.";
            public const string AuthorizationInvalid = "Authentication failed, check if the token key is provided or doesn't expire.";
            public const string SortingInvalid = "The sorting format is invalid.";
            public const string PropertyInvalid = "The property {0} is not supported.";
            public const string PropertyNull = "The property {0} can not be null or empty.";
        }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public enum ErrorType
    {
        Business,
        Technical
    }
}
