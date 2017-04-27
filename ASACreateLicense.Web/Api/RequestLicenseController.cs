using Antlr.Runtime.Misc;
using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASACreateLicense.Service.Services;
using ASACreateLicense.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ASACreateLicense.Web.Api
{
   // [Authorize]
    [RoutePrefix("api/requestlicenses")]
    public class RequestLicenseController : ApiController
    {
        private RequestLicenseService _requestLicenseService = new RequestLicenseService();
        private CustomerInfoService _customerInfoService = new CustomerInfoService();

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(
            DateTime fromDate, DateTime endDate, int statusLicenseId, int viewAll,
            int page, int pageSize)
        {
            int totalRow = 0;
            var list = _requestLicenseService.GetAll(fromDate, endDate, statusLicenseId, viewAll);
            totalRow = list.Count();

            var query = list.Skip((page) * pageSize).Take(pageSize);        

            var paginationset = new PaginationSet<RequestListViewModel>()
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
            var list = _requestLicenseService.GetById(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, list);
            return response;
        }

        [Route("sentemail")]
        [HttpGet]
        public HttpResponseMessage SentEmail(int id)
        {          
            var response = Request.CreateResponse(HttpStatusCode.OK, id);
            return response;
        }

        [Route("addcustomer")]
        [HttpGet]
        public HttpResponseMessage AddCustomer(int id)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool check = _requestLicenseService.AddCustomer(id);
                response = Request.CreateResponse(HttpStatusCode.Created, check);
            }

            return response;
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage AddRequestLicense(HttpRequestMessage request, RequestListViewModel requestListVM)
        {
           
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _requestLicenseService.AddRequestLicense(requestListVM);
                    response = request.CreateResponse(HttpStatusCode.Created, requestListVM);
                }

                return response;           
        }

        [Route("updatestatus")]
        [HttpPut]
        public HttpResponseMessage UpdateStatus(HttpRequestMessage request, int id, int statusLicenseId)
        {

            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                //var delData = _requestLicenseService.DeleteRequest(id);

                //if (delData != null)
                //    response = request.CreateResponse(HttpStatusCode.Created, delData);
                //else
                //    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return response;
        }


        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {

            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var delData = _requestLicenseService.DeleteRequest(id);

                if(delData != null)
                    response = request.CreateResponse(HttpStatusCode.Created, delData);
                else
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
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
                var listRequest = new JavaScriptSerializer().Deserialize<List<int>>(jsonlistId);

                foreach(var item in listRequest)
                {
                    _requestLicenseService.DeleteRequest(item);
                }

                response = request.CreateResponse(HttpStatusCode.OK, listRequest.Count());
               
            }
            return response;
        }
    }
}