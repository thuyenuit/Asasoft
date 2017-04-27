using ASACreateLicense.Models;
using ASACreateLicense.Service.Services;
using ASACreateLicense.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASACreateLicense.Web.Api
{
   // [Authorize]
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private RequestContactService requestContactService = new RequestContactService();

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(bool status, int page, int pageSize)
        {
            int totalRow = 0;
            var list = requestContactService.GetAll(status);
            totalRow = list.Count();

            var query = list.Skip((page) * pageSize).Take(pageSize);

            var paginationset = new PaginationSet<RequestContact>()
            {
                Items = query.ToList(),
                Page = page,
                TotalCount = totalRow,
                TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationset);
            return response;
        }

        [Route("updatestatus")]
        [HttpGet]
        public HttpResponseMessage UpdateStatus(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = requestContactService.UpdateStatus(id);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            bool check = requestContactService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, check);
        }

    }
}
