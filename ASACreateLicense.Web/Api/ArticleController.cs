using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASACreateLicense.Service.Services;
using ASACreateLicense.Web.Infrastructure;
using ASALibrary.ASA.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ASACreateLicense.Web.Api
{
    //[Authorize]
    [RoutePrefix("api/article")]
    public class ArticleController : ApiController
    {
        private ArticleService articleService = new ArticleService();
        private ASABaseContext ctr = new ASABaseContext();

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(int page, int pageSize)
        {
            int totalRow = 0;
            var list = articleService.GetAll();
            totalRow = list.Count();

            var query = list.Skip((page) * pageSize).Take(pageSize);

            var paginationset = new PaginationSet<ArticleViewModel>()
            {
                Items = query.ToList(),
                Page = page,
                TotalCount = totalRow,
                TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationset);
            return response;
        }

        [Route("getallnopaging")]
        [HttpGet]
        public HttpResponseMessage GetAllNoPaging()
        {
            var serializeData = JsonConvert.SerializeObject(articleService.GetAll());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [Route("getob")]
        [HttpGet]
        public HttpResponseMessage GetOb(HttpRequestMessage request, int id)
        {
            var resultData = articleService.GetOb(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, resultData);
            return response;
        }

        [Route("getbycontracttype")]
        [HttpGet]
        public HttpResponseMessage GetByContractType(HttpRequestMessage request, int id)
        {
            var resultData = articleService.GetByContractType(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, resultData);
            return response;
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage AddArticle(HttpRequestMessage request, ArticleViewModel articleVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = articleService.AddArticle(articleVM);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage UpdateArticle(HttpRequestMessage request, ArticleViewModel articleVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = articleService.UpdateArticle(articleVM);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }

        [Route("getbymultiid")]
        [HttpGet]
        public HttpResponseMessage GetByMultiId(HttpRequestMessage request, string jsonlistId)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                List<Article> list = new List<Article>();

                if (jsonlistId.Length != 2)
                {
                    var listLicense = new JavaScriptSerializer().Deserialize<List<int>>(jsonlistId);
                    list = ctr.LoadListObject<Article>().Where(x => listLicense.Contains(x.ID)).ToList();
                }

                response = request.CreateResponse(HttpStatusCode.OK, list);
            }
            return response;
        }
    }
}
