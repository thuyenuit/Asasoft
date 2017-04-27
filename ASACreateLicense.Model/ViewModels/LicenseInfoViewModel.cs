using ASACreateLicense.Model.Models;
using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.ViewModels
{
    public class LicenseInfoViewModel: LicenseInfo
    {
        private string _CustomerName;
        public static string COL_CustomerName = "CustomerName";
        [Column(Name = "CustomerName")]
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
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


        private string _Company;
        public static string COL_Company = "Company";
        [Column(Name = "Company")]
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        private string _Phone;
        public static string COL_Phone = "Phone";
        [Column(Name = "Phone")]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Address;
        public static string COL_Address = "Address";
        [Column(Name = "Address")]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private bool _Limit;
        public static string COL_Limit = "Limit";
        [Column(Name = "Limit")]
        public bool Limit
        {
            get { return _Limit; }
            set { _Limit = value; }
        }
    }
}
