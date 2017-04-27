using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class LicenseInfo : EntityBase
    {
        public static string TAB_Name = "LicenseInfo";

        private int _LicenseID;
        public static string COL_LicenseID = "LicenseID";
        [Keys]
        [Identity]
        [Column(Name = "LicenseID")]
        public int LicenseID
        {
            get { return _LicenseID; }
            set { _LicenseID = value; }
        }

        private int _CustomerID;
        public static string COL_CustomerID = "CustomerID";
        [Column(Name = "CustomerID")]
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
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

        private string _License;
        public static string COL_License = "License";
        [Column(Name = "License")]
        public string License
        {
            get { return _License; }
            set { _License = value; }
        }

        private DateTime _CreateDate;
        public static string COL_CreateDate = "CreateDate";
        [Column(Name = "CreateDate")]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        private DateTime _UpdateDate;
        public static string COL_UpdateDate = "UpdateDate";
        [Column(Name = "UpdateDate")]
        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }

        private DateTime _BeginDate;
        public static string COL_BeginDate = "BeginDate";
        [Column(Name = "BeginDate")]
        public DateTime BeginDate
        {
            get { return _BeginDate; }
            set { _BeginDate = value; }
        }

        private DateTime _EndDate;
        public static string COL_EndDate = "EndDate";
        [Column(Name = "EndDate")]
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        private int _ContractTypeID;
        public static string COL_ContractTypeID = "ContractTypeID";
        [Column(Name = "ContractTypeID")]
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }

        private string _ContractNumber;
        public static string COL_ContractNumber = "ContractNumber";
        [Column(Name = "ContractNumber")]
        public string ContractNumber
        {
            get { return _ContractNumber; }
            set { _ContractNumber = value; }
        }

        private int _StatusLicenseID;
        public static string COL_StatusLicenseID = "StatusLicenseID";
        [Column(Name = "StatusLicenseID")]
        public int StatusLicenseID
        {
            get { return _StatusLicenseID; }
            set { _StatusLicenseID = value; }
        }
    }
}
