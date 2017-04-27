using ASACreateLicense.Model.ViewModels;
using ASACreateLicense.Service.Services;
using ASACreateLicense.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASACreateLicense.Web.Api
{
   // [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private TUserService tUserService = new TUserService();

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(string keyword,int page, int pageSize)
        {
            int totalRow = 0;
            var list = tUserService.GetAll(keyword);
            totalRow = list.Count();

            var query = list.Skip((page) * pageSize).Take(pageSize);

            var paginationset = new PaginationSet<TUserViewModel>()
            {
                Items = query.ToList(),
                Page = page,
                TotalCount = totalRow,
                TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationset);
            return response;
        }

        [Route("selectbyemail")]
        [HttpGet]
        public HttpResponseMessage SelectByEmail(string email)
        {
            bool checkData = tUserService.SelectByEmail(email);
            var response = Request.CreateResponse(HttpStatusCode.OK, checkData);
            return response;
        }

        [Route("checkemailuserwhenupdate")]
        [HttpGet]
        public HttpResponseMessage CheckEmailUserWhenUpdate(string username, string email)
        {
            bool checkData = tUserService.CheckEmailUserWhenUpdate(username, email);
            var response = Request.CreateResponse(HttpStatusCode.OK, checkData);
            return response;
        }

        [Route("selectbyusername")]
        [HttpGet]
        public HttpResponseMessage SelectByUsername(string username)
        {
            bool checkData = tUserService.SelectByUsername(username);
            var response = Request.CreateResponse(HttpStatusCode.OK, checkData);
            return response;
        }

        [Route("getbyusername")]
        [HttpGet]
        public HttpResponseMessage GetByUsername(HttpRequestMessage request, string username)
        {
            var data = tUserService.GetByUsername(username);
            var response = Request.CreateResponse(HttpStatusCode.OK, data);
            return response;
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage AddUser(HttpRequestMessage request, TUserViewModel tUserVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = tUserService.AddUser(tUserVM);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage UpdateUser(HttpRequestMessage request, TUserViewModel tUserVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = tUserService.UpdateUser(tUserVM);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }

        [Route("changepasss")]
        [HttpPut]
        public HttpResponseMessage ChangePassword(HttpRequestMessage request, TUserViewModel tUserVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = tUserService.ChangePassword(tUserVM.Username, tUserVM.NewPassword);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }

      


        //[HttpGet]
        //[AllowAnonymous]
        //[Route("login")]
        //public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password)
        //{
        //    HttpResponseMessage response = null;
        //    if (!ModelState.IsValid)
        //    {
        //        return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //    else
        //    {
        //        int checkData = await tUserService.GetUserByUsernamePassword(userName, password);
        //        response = request.CreateResponse(HttpStatusCode.OK, checkData);
        //    }

        //    return response;
        //}
    }
}
