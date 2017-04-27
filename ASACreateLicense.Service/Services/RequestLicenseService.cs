using ASACreateLicense.Data.Implements;
using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;

namespace ASACreateLicense.Service.Services
{
    public class RequestLicenseService
    {
        private ASABaseContext ctr = new ASABaseContext();
        private RequestLicenseData requestLicenseData = new RequestLicenseData();

        public IEnumerable<RequestListViewModel> GetAll(DateTime fromDate, DateTime endDate, int statusLicenseId, int viewAll)
        {
            return requestLicenseData.GetAll(fromDate, endDate, statusLicenseId, viewAll);
        }

        public IEnumerable<RequestListViewModel> GetById(int id)
        {
            return requestLicenseData.GetAllById(id);
        }

        public void AddRequestLicense(RequestListViewModel requestList)
        {
            requestLicenseData.AddRequestLicense(requestList);
        }


        public bool AddCustomer(int idRequest)
        {
            bool check = requestLicenseData.AddCustomer(idRequest);
            return check;
        }


        public RequestList DeleteRequest(int id)
        {
            return requestLicenseData.DeleteRequest(id);
        }
    }
}