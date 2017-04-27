using ASACreateLicense.Model.ViewModels;
using ASACreateLicense.Service.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASACreateLicense.Web.Api
{
    [RoutePrefix("api/serverconfig")]
    public class ServerConfigController : ApiController
    {
        private ServerConfigService serverConfigService = new ServerConfigService();

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage ServerClient(HttpRequestMessage request, ServerConfigViewModel serverVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = serverConfigService.ServerClient(serverVM.ServerName, serverVM.UserName, serverVM.Password, serverVM.Database, serverVM.Option);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }
    }
}