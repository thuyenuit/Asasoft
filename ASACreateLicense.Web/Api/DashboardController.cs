using ASACreateLicense.Service.Services;
using ASALibrary.ASA.Common;
using ASALibrary.ASA.Controller.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASACreateLicense.Web.Api
{
    //[Authorize]
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        private RequestLicenseService _requestLicenseService = new RequestLicenseService();
        private LicenseInfoService _licenseInfoService = new LicenseInfoService();
        private CustomerInfoService _customerInfoService = new CustomerInfoService();

        [Route("defaultlanguage")]
        [HttpGet]
        public HttpResponseMessage DefaultLanguage()
        {
            string lg = ASALibrary.ASA.Controller.Session.SessionHelper.GetSession() == null ? ASALibrary.ASA.Common.SystemDefine.SystemLanguage : (ASALibrary.ASA.Controller.Session.SessionHelper.GetSession() as ASALibrary.ASA.Controller.Session.SessionManagement).SystemLanguage;
            var response = Request.CreateResponse(HttpStatusCode.OK, lg);
            return response;
        }

        // set Language
        [Route("setlanguage")]
        [HttpGet]
        public HttpResponseMessage SetLanguage(string lgID)
        {          
            if (lgID != null)
            {
                SessionManagement sm = SessionHelper.GetSession() as SessionManagement;
                if ((sm == null ? SystemDefine.SystemLanguage : sm.SystemLanguage) == "EN")
                {
                    lgID = "VI";
                }
                else
                {
                    lgID = "EN";
                }
                SystemDefine.SystemLanguage = lgID;
                if (sm != null)
                    sm.SystemLanguage = lgID;
                SystemLanguageWeb.LoadListLanguage(SystemDefine.PROJECTNAME);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, lgID);
            return response;
        }

        [Route("getrequestlicensetoday")]
        [HttpGet]
        public HttpResponseMessage GetRequestLicenseToday()
        {                   
            DateTime date = SystemDefine.SystemDate.Date;
            var list = _requestLicenseService.GetAll(date, date, -1, 1);         
            var response = Request.CreateResponse(HttpStatusCode.OK, list);
            return response;
        }

        [Route("getlicensenotified")]
        [HttpGet]
        public HttpResponseMessage GetLicenseNotified()
        {
            var list = _licenseInfoService.GetLicenseNotified();
            var response = Request.CreateResponse(HttpStatusCode.OK, list);
            return response;
        }

        [Route("totalcustomer")]
        [HttpGet]
        public HttpResponseMessage TotalCountCustomer()
        {
            int total = _customerInfoService.TotalCountCustomer();
            var response = Request.CreateResponse(HttpStatusCode.OK, total);
            return response;
        }
    }
}
