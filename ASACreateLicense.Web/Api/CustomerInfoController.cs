using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASACreateLicense.Service.Services;
using ASACreateLicense.Web.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ASACreateLicense.Web.Api
{
   // [Authorize]
    [RoutePrefix("api/customerinfo")]
    public class CustomerInfoController : ApiController
    {
        private CustomerInfoService customerInfoService = new CustomerInfoService();

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(string keyword, int page, int pageSize)
        {
            int totalRow = 0;
            var list = customerInfoService.GetAll(keyword);
            totalRow = list.Count();

            var query = list.Skip((page) * pageSize).Take(pageSize);

            var paginationset = new PaginationSet<CustomerInfoViewModel>()
            {
                Items = query.ToList(),
                Page = page,
                TotalCount = totalRow,
                TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationset);
            return response;
        }

        [Route("getbyid/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            //List<CustomerInfo> list = customerInfoService
            //var response = Request.CreateResponse(HttpStatusCode.OK, list);
            //return response;

            var serializeData = JsonConvert.SerializeObject(customerInfoService.GetById(id));
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [Route("getallcustomer")]
        [HttpGet]
        public HttpResponseMessage GetAllCustomer()
        {
            var serializeData = JsonConvert.SerializeObject(customerInfoService.GetAllCustomer());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [Route("addcustomer")]
        [HttpPost]
        public HttpResponseMessage AddCustomer(HttpRequestMessage request, CustomerInfoViewModel CustomerInfoVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = customerInfoService.AddCustomer(CustomerInfoVM);
                response = request.CreateResponse(HttpStatusCode.OK, checkData);
            }
            return response;         
        }


        [Route("updatecustomer")]
        [HttpPut]
        public HttpResponseMessage UpdateCustomer(HttpRequestMessage request, CustomerInfoViewModel CustomerInfoVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = customerInfoService.UpdateCustomer(CustomerInfoVM);
                response = request.CreateResponse(HttpStatusCode.OK, checkData);
            }
            return response;
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = customerInfoService.Delete(id);
                response = request.CreateResponse(HttpStatusCode.OK, checkData);
            }
            return response;
        }      
    }
}