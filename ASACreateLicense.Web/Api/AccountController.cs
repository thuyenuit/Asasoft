using ASACreateLicense.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASACreateLicense.Web.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private TUserService tUserService = new TUserService();

        [HttpGet]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
            int result = await tUserService.GetUserByUsernamePassword(userName, password);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
