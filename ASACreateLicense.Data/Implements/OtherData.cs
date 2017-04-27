using ASACreateLicense.Model.Models;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Data.Implements
{
    public class OtherData
    {
        private ASABaseContext ctr = new ASABaseContext();

        public List<City> GetAllCity()
        {
            List<City> list = new List<City>();
            list = ctr.LoadListObject<City>();
            return list.ToList();
        }

        public List<CustomerType> GetAllCustomerType()
        {
            List<CustomerType> list = new List<CustomerType>();
            list = ctr.LoadListObject<CustomerType>();
            return list.ToList();
        }

        public List<ContractType> GetAllContractType()
        {
            List<ContractType> list = new List<ContractType>();
            list = ctr.LoadListObject<ContractType>();
            return list.ToList();
        }

        public List<StatusLicense> GetAllStatusLicense()
        {
            List<StatusLicense> list = new List<StatusLicense>();
            list = ctr.LoadListObject<StatusLicense>();
            return list.ToList();
        }

        public List<UnitInfo> GetUnit()
        {
            List<UnitInfo> list = new List<UnitInfo>();
            list = ctr.LoadListObject<UnitInfo>();
            return list.ToList();
        }

        public UnitInfo GetUnitInfo()
        {
            var result = GetUnit().FirstOrDefault(x => x.ID == 1);
            if (result != null)
                return result;
            return null;
        }
    }
}
