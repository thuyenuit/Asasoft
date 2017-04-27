using ASACreateLicense.Model.ViewModels;
using ASACreateLicense.Service.Services;
using ASACreateLicense.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ASACreateLicense.Web.Api
{
   // [Authorize]
    [RoutePrefix("api/licenseinfo")]
    public class LicenseInfoController : ApiController
    {
        private LicenseInfoService licenseInfoService = new LicenseInfoService();

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(
            DateTime fromCreateDate, DateTime toCreateDate, DateTime fromEndDate, DateTime toEndDate,
            int statusId, string keyword, int contractId, int viewAll, int page, int pageSize)
        {
            int totalRow = 0;
            var list = licenseInfoService.GetAll(fromCreateDate, toCreateDate, fromEndDate, toEndDate, statusId, keyword, contractId, viewAll);
            totalRow = list.Count();

            var query = list.Skip((page) * pageSize).Take(pageSize);

            var paginationset = new PaginationSet<LicenseInfoViewModel>()
            {
                Items = query.ToList(),
                Page = page,
                TotalCount = totalRow,
                TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationset);
            return response;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {         
            var resultData = licenseInfoService.GetById(id);
            
            var response = Request.CreateResponse(HttpStatusCode.OK, resultData);
            return response;
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string jsonlistId)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var listLicense = new JavaScriptSerializer().Deserialize<List<int>>(jsonlistId);

                foreach (var item in listLicense)
                {
                    licenseInfoService.DeleteLicenseInfo(item);
                }

                response = request.CreateResponse(HttpStatusCode.OK, listLicense.Count());

            }
            return response;
        }
    }
}
