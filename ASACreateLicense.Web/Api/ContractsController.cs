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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web.HtmlReportRender;
using ASACreateLicense.Web.Pdf;
using ASACreateLicense.Model.Models;
using System.IO;
using System.Web;
using System.Net.Http.Headers;


namespace ASACreateLicense.Web.Api
{
    [RoutePrefix("api/contract")]
    public class ContractsController : ApiController
    {
        private ContractsService contractsService = new ContractsService();

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(string keyword, int contracttype, bool isLock, int page, int pageSize)
        {
            int totalRow = 0;
            var list = contractsService.GetAll(keyword, contracttype, isLock);
            totalRow = list.Count();

            var query = list.Skip((page) * pageSize).Take(pageSize);

            var paginationset = new PaginationSet<ContractsViewModel>()
            {
                Items = query.ToList(),
                Page = page,
                TotalCount = totalRow,
                TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationset);
            return response;
        }


        [Route("getbyid")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            var resultData = contractsService.GetByID(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, resultData);
            return response;
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage CreateContract(HttpRequestMessage request, ContractsViewModel contractsVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = contractsService.CreateContract(contractsVM);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
            }

            return response;
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage UpdateContract(HttpRequestMessage request, ContractsViewModel contractsVM)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                bool checkData = contractsService.UpdateContract(contractsVM);
                response = request.CreateResponse(HttpStatusCode.Created, checkData);
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
                var listContracts = new JavaScriptSerializer().Deserialize<List<int>>(jsonlistId);

                foreach (var item in listContracts)
                {
                    contractsService.DeleteContracts(item);
                }
                response = request.CreateResponse(HttpStatusCode.OK, listContracts.Count());
            }
            return response;
        }


        [Route("printpdf")]
        [HttpGet]
        public HttpResponseMessage GetReport()
        {      
            var list = contractsService.GetAll("", 1, false);
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var strReportName = "CrystalReport1.rpt";
            var rd = new ReportDocument();
            string strPath = HttpContext.Current.Server.MapPath("~/") + "Reports//" + strReportName;
            rd.Load(strPath);
            rd.SetDataSource(list);
            var tip = ExportFormatType.PortableDocFormat;
            var pdf = rd.ExportToStream(tip);
            response.Headers.Clear();
            response.Content = new StreamContent(pdf);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return response;
        }

    }
}