using ASALibrary.ASA.Domain;
using System;

namespace ASACreateLicense.Model.Models
{
    public partial class RequestList : EntityBase
    {
        public static string TAB_Name = "RequestList";

        private int _ID;
        public static string COL_ID = "ID";

        [Keys]
        [Identity]
        [Column(Name = "ID")]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _CustomerName;
        public static string COL_CustomerName = "CustomerName";

        [Column(Name = "CustomerName")]
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        private string _Company;
        public static string COL_Company = "Company";

        [Column(Name = "Company")]
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        private string _ServerName;
        public static string COL_ServerName = "ServerName";

        [Column(Name = "ServerName")]
        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }

        private string _Keys;
        public static string COL_Keys = "Keys";

        [Column(Name = "Keys")]
        public string Keys
        {
            get { return _Keys; }
            set { _Keys = value; }
        }

        private string _Phone;
        public static string COL_Phone = "Phone";

        [Column(Name = "Phone")]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Fax;
        public static string COL_Fax = "Fax";

        [Column(Name = "Fax")]
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        private string _Email;
        public static string COL_Email = "Email";

        [Column(Name = "Email")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Address;
        public static string COL_Address = "Address";

        [Column(Name = "Address")]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _CityID;
        public static string COL_CityID = "CityID";

        [Column(Name = "CityID")]
        public string CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }

        private string _Country;
        public static string COL_Country = "Country";

        [Column(Name = "Country")]
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private int? _ContractTypeID;
        public static string COL_ContractTypeID = "ContractTypeID";

        [Column(Name = "ContractTypeID")]
        public int? ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }

        private int? _StatusLicenseID;
        public static string COL_StatusLicenseID = "StatusLicenseID";

        [Column(Name = "StatusLicenseID")]
        public int? StatusLicenseID
        {
            get { return _StatusLicenseID; }
            set { _StatusLicenseID = value; }
        }

        private string _CompanyCode;
        public static string COL_CompanyCode = "CompanyCode";

        [Column(Name = "CompanyCode")]
        public string CompanyCode
        {
            get { return _CompanyCode; }
            set { _CompanyCode = value; }
        }

        private DateTime? _CreateDate;
        public static string COL_CreateDate = "CreateDate";

        [Column(Name = "CreateDate")]
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        private int? _CustomerTypeID;
        public static string COL_CustomerTypeID = "CustomerTypeID";

        [Column(Name = "CustomerTypeID")]
        public int? CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set { _CustomerTypeID = value; }
        }

        private bool? _Applied;
        public static string COL_Applied = "Applied";

        [Column(Name = "Applied")]
        public bool? Applied
        {
            get { return _Applied; }
            set { _Applied = value; }
        }
    }
}