using ASACreateLicense.Model.Models;
using ASALibrary.ASA.Common;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASACreateLicense.Data.Implements;
using ASACreateLicense.Model.ViewModels;

namespace ASACreateLicense.Service.Services
{
    public class CustomerInfoService
    {
        ASABaseContext ctr = new ASABaseContext();
        private CustomerInfoData cus = new CustomerInfoData();
        
        public List<CustomerInfoViewModel> GetAll(string keyword)
        {
            return cus.GetByKeyword(keyword);
        }

        public List<CustomerInfoViewModel> GetAllCustomer()
        {
            return cus.GetAllCustomer();
        }

        public int TotalCountCustomer()
        {
            return cus.TotalCountCustomer();
        }

        public CustomerInfo GetById(int id)
        {
            return cus.GetById(id);
        }

        public bool AddCustomer(CustomerInfoViewModel customerInfoVM)
        {
            return cus.AddCusstomer(customerInfoVM);
        }

        public bool UpdateCustomer(CustomerInfoViewModel customerInfoVM)
        {
            return cus.UpdateCustomer(customerInfoVM);
        }

        public bool Delete(int id)
        {
            return cus.Delete(id);
        }         
    }
}
