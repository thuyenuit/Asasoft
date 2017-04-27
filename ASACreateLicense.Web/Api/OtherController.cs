using ASACreateLicense.Service.Services;
using ASALibrary.ASA.Common;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ASACreateLicense.Web.Api
{
    //[Authorize]
    [RoutePrefix("api/other")]
    public class OtherController : ApiController
    {
        private OtherService _otherService = new OtherService();

        [Route("getcurrentdate")]
        [HttpGet]
        public HttpResponseMessage GetCurrentDate()
        {
            DateTime date = SystemDefine.SystemDate.Date;
            var response = Request.CreateResponse(HttpStatusCode.OK, date.Date);
            return response;
        }

        [Route("getallcity")]
        [HttpGet]
        public HttpResponseMessage GetAllCity()
        {
            var serializeData = JsonConvert.SerializeObject(_otherService.GetAllCity());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [Route("getallcustomertype")]
        [HttpGet]
        public HttpResponseMessage GetAllCustomerType()
        {
            var serializeData = JsonConvert.SerializeObject(_otherService.GetAllCustomerType());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [Route("getallcontracttype")]
        [HttpGet]
        public HttpResponseMessage GetAllContractType()
        {
            var serializeData = JsonConvert.SerializeObject(_otherService.GetAllContractType());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [Route("getallstatuslicense")]
        [HttpGet]
        public HttpResponseMessage GetAllStatusLicense()
        {
            var serializeData = JsonConvert.SerializeObject(_otherService.GetAllStatusLicense());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [Route("unitinfo")]
        [HttpGet]
        public HttpResponseMessage GetUnitInfo(HttpRequestMessage request)
        {
            var resultData = _otherService.GetUnitInfo();
            var response = Request.CreateResponse(HttpStatusCode.OK, resultData);
            return response;
        }
    }
}