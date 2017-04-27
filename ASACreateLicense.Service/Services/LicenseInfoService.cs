using ASACreateLicense.Data.Implements;
using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Common;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Service.Services
{
    public class LicenseInfoService
    {
        private LicenseInfoData licenseInfoData = new LicenseInfoData();

        public IEnumerable<LicenseInfoViewModel> GetAll(
            DateTime fromCreateDate, DateTime toCreateDate,
            DateTime fromEndDate, DateTime toEndDate,
            int statusId, string keyword, int contractId, int viewAll)
        {
            return licenseInfoData.GetAll(fromCreateDate, toCreateDate, fromEndDate, toEndDate, statusId, keyword, contractId, viewAll);
        }

        public IEnumerable<LicenseInfoViewModel> GetLicenseNotified() {
            return licenseInfoData.GetLicenseNotified();
        }

        public LicenseInfo GetById(int id)
        {
            return licenseInfoData.GetAllById(id);
        }

        public LicenseInfo DeleteLicenseInfo(int id) {
            return licenseInfoData.DeleteLicenseInfo(id);
        }

        //public void InsertLicenseInfoWhenCustomerRequest(int _customerID, string _serverName,
        //    string _key, string _license, int _contractTypeId, int _statusLicenseId)
        //{
        //    LicenseInfo cus = new LicenseInfo()
        //    {
        //        CustomerID = _customerID,
        //        ServerName = _serverName,
        //        Keys = _Keys,
        //        License = _license,
        //        CreateDate = SystemDefine.SystemDate.Date,
        //        UpdateDate = SystemDefine.SystemDate.Date,
        //        BeginDate = SystemDefine.SystemDate.Date,
        //        EndDate = SystemDefine.SystemDate.Date,
        //        ContractTypeID = _contractTypeId,
        //        ContractNumber = "",
        //        StatusLicenseID = _statusLicenseId,
        //    };
        //    ctr.Insert<LicenseInfo>(cus);
        //}


        //public List<LicenseInfoViewModel> LicenseList(string createDateFrom, string createDateTo, string endDateFrom, string endDateTo,
        //    int statusLicenseId, int contractTypeId, string keyword)
        //{
        //    DataTable dt = new DataTable();

        //    if (keyword.Length == 0)
        //        keyword = string.Empty;

        //    if (string.IsNullOrEmpty(createDateFrom) || string.IsNullOrEmpty(createDateTo))
        //    {
        //        createDateFrom = "";
        //        createDateTo = "";
        //    }
        //    if (string.IsNullOrEmpty(endDateFrom) || string.IsNullOrEmpty(endDateTo))
        //    {
        //        endDateFrom = "";
        //        endDateTo = "";
        //    }

        //    if (!string.IsNullOrEmpty(createDateFrom)) // ngày khởi tạo
        //    {
        //        DateTime dateFrom, dateTo;
        //        DateTime.TryParse(createDateFrom, out dateFrom);
        //        DateTime.TryParse(createDateTo, out dateTo);

        //        dt = ctr.LoadListDTByStr("exec LicenseInfo_List '" + dateFrom.Date.ToString(SystemFormatString.SQLDate) + "', '" + dateTo.Date.ToString(SystemFormatString.SQLDate) + "', '" + endDateFrom + "', '" + endDateTo + "','" + statusLicenseId + "', '" + keyword + "', '" + contractTypeId + "'");
        //    }
        //    else if (!string.IsNullOrEmpty(endDateFrom)) // ngày hết hạn
        //    {
        //        DateTime dateFrom, dateTo;
        //        DateTime.TryParse(endDateFrom, out dateFrom);
        //        DateTime.TryParse(endDateTo, out dateTo);
        //        dt = ctr.LoadListDTByStr("exec LicenseInfo_List '" + createDateFrom + "', '" + createDateTo + "', '" + dateFrom.Date.ToString(SystemFormatString.SQLDate) + "', '" + dateTo.Date.ToString(SystemFormatString.SQLDate) + "','" + statusLicenseId + "', '" + keyword + "', '" + contractTypeId + "'");
        //    }
        //    else if (!string.IsNullOrEmpty(createDateFrom) && !string.IsNullOrEmpty(endDateFrom)) // ngày tạo và ngày hết hạn
        //    {
        //        DateTime createdateFrom, createdateTo, enddateFrom, enddateTo;
        //        DateTime.TryParse(createDateFrom, out createdateFrom);
        //        DateTime.TryParse(createDateTo, out createdateTo);
        //        DateTime.TryParse(endDateFrom, out enddateFrom);
        //        DateTime.TryParse(endDateTo, out enddateTo);
        //        dt = ctr.LoadListDTByStr("exec LicenseInfo_List '" + createdateFrom.Date.ToString(SystemFormatString.SQLDate) + "', '" + createdateTo.Date.ToString(SystemFormatString.SQLDate) + "', '" + enddateFrom.Date.ToString(SystemFormatString.SQLDate) + "', '" + enddateTo.Date.ToString(SystemFormatString.SQLDate) + "','" + statusLicenseId + "', '" + keyword + "', '" + contractTypeId + "'");
        //    }
        //    else if (string.IsNullOrEmpty(createDateFrom) && string.IsNullOrEmpty(endDateFrom))
        //    {
        //        string date = "";
        //        string a = "exec LicenseInfo_List '" + date + "', '" + date + "', '" + date + "', '" + date + "','" + statusLicenseId + "', N'" + keyword + "', '" + contractTypeId + "'";
        //        dt = ctr.LoadListDTByStr("exec LicenseInfo_List '" + date + "', '" + date + "', '" + date + "', '" + date + "','" + statusLicenseId + "', N'" + keyword + "', '" + contractTypeId + "'");
        //    }

        //    List<LicenseInfoViewModel> result = new List<LicenseInfoViewModel>();
        //    result = (from DataRow dr in dt.Rows
        //              select new LicenseInfoViewModel()
        //              {
        //                  LicenseID = Convert.ToInt32(dr["LicenseID"]),
        //                  CustomerName = dr["CustomerName"].ToString(),
        //                  ServerName = dr["ServerName"].ToString(),
        //                  Keys = dr["Keys"].ToString(),
        //                  License = dr["License"].ToString(),
        //                  CreateDate = Convert.ToDateTime(dr["CreateDate"], null),
        //                  DateCreate = Convert.ToDateTime(dr["CreateDate"]).ToString("dd/MM/yyyy"),
        //                  UpdateDate = Convert.ToDateTime(dr["UpdateDate"], null),
        //                  DateUpdate = Convert.ToDateTime(dr["UpdateDate"]).ToString("dd/MM/yyyy"),
        //                  BeginDate = Convert.ToDateTime(dr["BeginDate"], null),
        //                  DateBegin = Convert.ToDateTime(dr["BeginDate"]).ToString("dd/MM/yyyy"),
        //                  EndDate = Convert.ToDateTime(dr["EndDate"], null),
        //                  DateEnd = Convert.ToDateTime(dr["EndDate"]).ToString("dd/MM/yyyy"),
        //                  ContractTypeName = dr["ContractTypeName"].ToString(),
        //                  StatusLicenseName = dr["StatusLicenseName"].ToString(),
        //                  //  ContractNumber = dr["ContractNumber"].ToString(),                                               
        //              }).ToList();

        //    return result;
        //}

        //public List<StatusLicense> ListStatusLicenseByValue(int id)
        //{
        //    List<StatusLicense> list = ctr.LoadListObject<StatusLicense>();

        //    var result = from li in list
        //                 where li.StatusLicenseID != id
        //                 select li;

        //    return result.ToList();
        //}
    }
}
