using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Common;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASACreateLicense.Data.Implements
{
    public class CustomerInfoData
    {
        private ASABaseContext ctr = new ASABaseContext();

        public List<CustomerInfo> GetAll()
        {
            List<CustomerInfo> list = new List<CustomerInfo>();
            list = ctr.LoadListObject<CustomerInfo>();

            return list.ToList();
        }

        public int TotalCountCustomer()
        {
            var result = from a in GetAll().ToList()
                         where a.StatusID != 3
                         select a;
            return result.ToList().Count();
        }

        public List<CustomerInfoViewModel> GetByKeyword(string keyword)
        {
            string sqlString = "exec Customer_Search N'" + keyword + "'";
            IEnumerable<CustomerInfoViewModel> list = ctr.LoadListObjectByStr<CustomerInfoViewModel>(sqlString);
            return list.ToList();            
        }

        public List<CustomerInfoViewModel> GetAllCustomer()
        {
            string sql = "exec Customer_Select";
            List<CustomerInfoViewModel> list = ctr.LoadListObjectByStr<CustomerInfoViewModel>(sql);
            return list.ToList();
        }

        public CustomerInfo GetById(int id)
        {
            var result = GetAllCustomer().FirstOrDefault(x => x.CustomerID == id);
            if (result != null)
                return result;
            return null;
        }

        public bool AddCusstomer(CustomerInfoViewModel customerInfoVM)
        {
            try
            {
                CustomerInfo newcustomerInfo = new CustomerInfo()
                {
                    CustomerName = customerInfoVM.CustomerName,
                    CompanyCode = customerInfoVM.CompanyCode,
                    Company = customerInfoVM.CompanyCode,
                    Phone = customerInfoVM.Phone,
                    Fax = customerInfoVM.Fax,
                    Email = customerInfoVM.Email,
                    Address = customerInfoVM.Address,
                    CityID = customerInfoVM.CityID,
                    Country = "Việt Nam", // tạm thời
                    Bank = customerInfoVM.Bank,
                    BankAccount = customerInfoVM.BankAccount,
                    TaxCode = customerInfoVM.TaxCode,
                    Remark = customerInfoVM.Remark,
                    CreateBy = "admin",                 /// tạm thời - chỉnh sau
                    CreateDate = SystemDefine.SystemDate.Date,
                    UpdateBy = "",
                    UpdateDate = SystemDefine.SystemDate.Date,
                    CustomerTypeID = customerInfoVM.CustomerTypeID,
                    StatusID = 1
                };
                ctr.Insert<CustomerInfo>(newcustomerInfo);

                return true;
            }
            catch { 
                
            }

            return false;
        }

        public bool UpdateCustomer(CustomerInfoViewModel customerInfoVM)
        {
            try
            {
                CustomerInfo customer = new CustomerInfo();
                customer.CustomerID = customerInfoVM.CustomerID;
                customer = ctr.GetObject<CustomerInfo>(customer);

                if (customer != null)
                {
                    customer.CustomerName = customerInfoVM.CustomerName;
                    customer.Company = customerInfoVM.Company;
                    customer.Phone = customerInfoVM.Phone;
                    customer.Fax = customerInfoVM.Fax;
                    customer.Email = customerInfoVM.Email;
                    customer.Address = customerInfoVM.Address;
                    customer.CityID = customerInfoVM.CityID;
                    customer.Bank = customerInfoVM.Bank;
                    customer.BankAccount = customerInfoVM.BankAccount;
                    customer.TaxCode = customerInfoVM.TaxCode;
                    customer.Remark = customerInfoVM.Remark;
                    customer.UpdateBy = "Admin";            // tạm thời
                    customer.UpdateDate = SystemDefine.SystemDate.Date;
                    customer.CustomerTypeID = customerInfoVM.CustomerTypeID;
                    customer.CompanyCode = customerInfoVM.CompanyCode;

                    ctr.Update<CustomerInfo>(customer);
                    return true;
                }
            }
            catch { 
                
            }
            return false;
        }

        public bool Delete(int id)
        {
            CustomerInfo customer = new CustomerInfo();
            customer.CustomerID = id;
            customer = ctr.GetObject<CustomerInfo>(customer);

            if (customer != null)
            {
                customer.StatusID = 3;
                ctr.Update<CustomerInfo>(customer);
                return true;
            }

            return false;
        }
    }
}