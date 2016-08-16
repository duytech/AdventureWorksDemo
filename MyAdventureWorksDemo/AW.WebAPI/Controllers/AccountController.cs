namespace AW.WebAPI.Controllers
{
    #region Using
    using Common.Constants;
    using Common.Helpers;
    using Jose;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using ViewModels;
    #endregion

    public class AccountController : ApiController
    {
        [Route("api/account/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginViewModel login)
        {
            if (login.UserName != ConfigurationHelper.AdminUserName || login.Password != ConfigurationHelper.AdminPassword)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Message.Common.RequestInvalid);

            var currentDate = DateTime.Now;

            var payload = new Dictionary<string, object>()
            {
                { "guid", Guid.NewGuid() },
                { "username", login.UserName },
                { "date", currentDate }
            };

            var secretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };

            var tokenString = JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);

            var token = new TokenViewModel
            {
                AccessToken = tokenString,
                UserName = login.UserName,
                Issued = currentDate.ToString("MMM d yyyy HH:mm:ss"),
                Expires = currentDate.AddHours(ConfigurationHelper.TokenExpiryTime).ToString("MMM d yyyy HH:mm:ss")
            };

            return Request.CreateResponse(HttpStatusCode.OK, token);
        }
    }
}
