using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Common;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Data.Implements
{
    public class RequestLicenseData
    {
        ASABaseContext ctr = new ASABaseContext();

        private CustomerInfoData customerInfoData = new CustomerInfoData();

        public IEnumerable<RequestListViewModel> GetAll(DateTime fromDate, DateTime endDate, int statusLicenseId, int viewAll)
        {
            string sqlString = string.Empty;

            if (viewAll == 1)
            {
                string date = "";
                sqlString = "exec RequestList_CheckList '" + date + "', '" + date + "', '" + statusLicenseId + "', '" + viewAll + "'";
            }
            else
            {
                string fromCD = fromDate.Date.ToString();
                if (fromCD == "01/01/1900 00:00:00")
                {
                    fromCD = "";
                    sqlString = "exec RequestList_CheckList '" + fromDate + "', '" + fromDate + "', '" + statusLicenseId + "','" + viewAll + "'";
                }
                else
                    sqlString = "exec RequestList_CheckList '" + fromDate.ToString(SystemFormatString.SQLDate) + "', '" + endDate.ToString(SystemFormatString.SQLDate) + "', '" + statusLicenseId + "','" + viewAll + "'";
            }         

            IEnumerable<RequestListViewModel> list = ctr.LoadListObjectByStr<RequestListViewModel>(sqlString);
            return list.ToList();
        }

        public RequestList DeleteRequest(int id) {
            var result = ctr.LoadListObject<RequestList>().FirstOrDefault(x => x.ID == id);

            if (result != null)
            {
                result.StatusLicenseID = 3;
                ctr.Update<RequestList>(result);
                return result;
            }

            return null;
        }

        public IEnumerable<RequestListViewModel> GetAllById(int id)
        {
            string sqlString = "exec RequestList_SearchById '" + id + "'";

            IEnumerable<RequestListViewModel> list = ctr.LoadListObjectByStr<RequestListViewModel>(sqlString);
            return list.ToList();
        }

        public bool AddCustomer(int idRequest)
        {
            List<RequestList> list = ctr.LoadListObject<RequestList>();
            var result = list.FirstOrDefault(x => x.ID == idRequest);
            if (result != null)
            { 
                // cập thật giá trị đã add customer
                result.Applied = true;
                ctr.Update<RequestList>(result);

                // new customer
                CustomerInfoViewModel newcustomerInfo = new CustomerInfoViewModel()
                {
                    CustomerName = result.CustomerName,
                    CompanyCode = result.CompanyCode,
                    Company = result.CompanyCode,
                    Phone = result.Phone,
                    Fax = result.Fax,
                    Email = result.Email,
                    Address = result.Address,
                    CityID = result.CityID,
                    Country = "Việt Nam", // tạm thời                   
                    CreateBy = "admin",   // tạm thời - chỉnh sau
                    CreateDate = SystemDefine.SystemDate.Date,
                    UpdateDate = SystemDefine.SystemDate.Date,
                    CustomerTypeID = result.CustomerTypeID,
                    StatusID = 1
               };
              bool checkData =  customerInfoData.AddCusstomer(newcustomerInfo);

              return true;
            }
            return false;
        }

        public void AddRequestLicense(RequestListViewModel re)
        {
            bool applied = false;
            List<CustomerInfo> listCus = ctr.LoadListObject<CustomerInfo>();

            if (re.CustomerTypeID != 1) // khách hàng lẻ
            {
                var result = listCus.FirstOrDefault(x => x.Email == re.Email);
                if (result != null)
                    applied = true;
                else
                    applied = false;
            }
            else // khách hàng côngty
            {
                var result = listCus.FirstOrDefault(x => x.CompanyCode == re.CompanyCode);
                if (result != null)
                    applied = true;
                else
                    applied = false;
            }

            try
            {
                RequestList request = new RequestList()
                {
                    CustomerName = re.CustomerName,
                    Company = re.Company,
                    CompanyCode = re.CompanyCode,
                    ServerName = re.ServerName,
                    Keys = re.Keys.ToString(),
                    Phone = re.Phone,
                    Fax = re.Fax,
                    Email = re.Email,
                    Address = re.Address,
                    CityID = re.CityID,
                    Country = "Việt Nam", // tạm thời
                    ContractTypeID = re.ContractTypeID,
                    StatusLicenseID = 1, // Chưa cấp phép
                    CustomerTypeID = re.CustomerTypeID,
                    CreateDate = SystemDefine.SystemDate.Date,
                    Applied = applied,
                };
                ctr.Insert<RequestList>(request);
            }
            catch
            {

            }
        }
    }
}
