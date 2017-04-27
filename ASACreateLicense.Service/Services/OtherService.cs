using ASACreateLicense.Data.Implements;
using ASACreateLicense.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Service.Services
{
    public class OtherService
    {
        private OtherData _otherData = new OtherData();

        public List<City> GetAllCity()
        {
            return _otherData.GetAllCity();
        }

        public List<CustomerType> GetAllCustomerType()
        {
            return _otherData.GetAllCustomerType();
        }

        public List<ContractType> GetAllContractType()
        {
            return _otherData.GetAllContractType();
        }

        public List<StatusLicense> GetAllStatusLicense()
        {
            return _otherData.GetAllStatusLicense();
        }

        public UnitInfo GetUnitInfo()
        {
            return _otherData.GetUnitInfo();
        }
    }
}
