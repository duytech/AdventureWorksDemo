using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Common.Constants
{
    public struct Message
    {
        public struct Common
        {
            public const string Successful = "The operation is successful.";
            public const string NotExist = "The {0} '{1}' does not exist in Adhis.";
            public const string RequestInvalid = "The request message is invalid.";
            public const string ExceptionOccurs = "An unexpected error occurred during process your request. Please contact your administrator.";
            public const string AuthorizationInvalid = "Authentication failed, check if the token key is provided or doesn't expire.";
        }
    }
}
