using ASACreateLicense.Model.Models;
using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.ViewModels
{
    public class RequestListViewModel: RequestList
    {      
        private string _CityName;
        public static string COL_CityName = "CityName";
        [Column(Name = "CityName")]
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        private string _ContractTypeName;
        public static string COL_ContractTypeName = "ContractTypeName";
        [Column(Name = "ContractTypeName")]
        public string ContractTypeName
        {
            get { return _ContractTypeName; }
            set { _ContractTypeName = value; }
        }

        private string _CustomerTypeName;
        public static string COL_CustomerTypeName = "CustomerTypeName";
        [Column(Name = "CustomerTypeName")]
        public string CustomerTypeName
        {
            get { return _CustomerTypeName; }
            set { _CustomerTypeName = value; }
        }

        private string _StatusLicenseName;
        public static string COL_StatusLicenseName = "StatusLicenseName";
        [Column(Name = "StatusLicenseName")]
        public string StatusLicenseName
        {
            get { return _StatusLicenseName; }
            set { _StatusLicenseName = value; }
        }
    }
}
