using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASALibrary.ASA.Domain;

namespace ASACreateLicense.Model.Models
{
    public class CustomerInfo : EntityBase
    {
        public static string TAB_Name = "CustomerInfo";

        private int _CustomerID;
        public static string COL_CustomerID = "CustomerID";
        [Keys]
        [Identity]
        [Column(Name = "CustomerID")]
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        private string _CustomerName;
        public static string COL_CustomerName = "CustomerName";
        [Column(Name = "CustomerName")]
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        private string _CompanyCode;
        public static string COL_CompanyCode = "CompanyCode";
        [Column(Name = "CompanyCode")]
        public string CompanyCode
        {
            get { return _CompanyCode; }
            set { _CompanyCode = value; }
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

        private string _Bank;
        public static string COL_Bank = "Bank";
        [Column(Name = "Bank")]
        public string Bank
        {
            get { return _Bank; }
            set { _Bank = value; }
        }

        private string _BankAccount;
        public static string COL_BankAccount = "BankAccount";
        [Column(Name = "BankAccount")]
        public string BankAccount
        {
            get { return _BankAccount; }
            set { _BankAccount = value; }
        }

        private string _TaxCode;
        public static string COL_TaxCode = "TaxCode";
        [Column(Name = "TaxCode")]
        public string TaxCode
        {
            get { return _TaxCode; }
            set { _TaxCode = value; }
        }

        private string _Remark;
        public static string COL_Remark = "Remark";
        [Column(Name = "Remark")]
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _CreateBy;
        public static string COL_CreateBy = "CreateBy";
        [Column(Name = "CreateBy")]
        public string CreateBy
        {
            get { return _CreateBy; }
            set { _CreateBy = value; }
        }

        private DateTime _CreateDate;
        public static string COL_CreateDate = "CreateDate";
        [Column(Name = "CreateDate")]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        private string _UpdateBy;
        public static string COL_UpdateBy = "UpdateBy";
        [Column(Name = "UpdateBy")]
        public string UpdateBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }

        private DateTime _UpdateDate;
        public static string COL_UpdateDate = "UpdateDate";
        [Column(Name = "UpdateDate")]
        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }

        private int? _CustomerTypeID;
        public static string COL_CustomerTypeID = "CustomerTypeID";
        [Column(Name = "CustomerTypeID")]
        public int? CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set { _CustomerTypeID = value; }
        }

        //
        private int _Status;
        public static string COL_Status = "Status";
        [Column(Name = "Status")]
        public int StatusID
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
