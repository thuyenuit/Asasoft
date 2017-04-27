using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class Contracts : EntityBase
    {
        public static string TAB_Name = "Contracts";

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

        private string _ContractNumber;
        public static string COL_ContractNumber = "ContractNumber";
        [Column(Name = "ContractNumber")]
        public string ContractNumber
        {
            get { return _ContractNumber; }
            set { _ContractNumber = value; }
        }

        private string _ContractName;
        public static string COL_ContractName = "ContractName";
        [Column(Name = "ContractName")]
        public string ContractName
        {
            get { return _ContractName; }
            set { _ContractName = value; }
        }

        private int _CustomerID;
        public static string COL_CustomerID = "CustomerID";
        [Column(Name = "CustomerID")]
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        private int _UnitInfoID;
        public static string COL_UnitInfoID = "UnitInfoID";
        [Column(Name = "UnitInfoID")]
        public int UnitInfoID
        {
            get { return _UnitInfoID; }
            set { _UnitInfoID = value; }
        }

        private string _ContractContent;
        public static string COL_ContractContent = "ContractContent";
        [Column(Name = "ContractContent")]
        public string ContractContent
        {
            get { return _ContractContent; }
            set { _ContractContent = value; }
        }

        private string _ContractTime;
        public static string COL_ContractTime = "ContractTime";
        [Column(Name = "ContractTime")]
        public string ContractTime
        {
            get { return _ContractTime; }
            set { _ContractTime = value; }
        }

        private string _Description1;
        public static string COL_Description1 = "Description1";
        [Column(Name = "Description1")]
        public string Description1
        {
            get { return _Description1; }
            set { _Description1 = value; }
        }

        private string _Description2;
        public static string COL_Description2 = "Description2";
        [Column(Name = "Description2")]
        public string Description2
        {
            get { return _Description2; }
            set { _Description2 = value; }
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

        private int _ContractTypeID;
        public static string COL_ContractTypeID = "ContractTypeID";
        [Column(Name = "ContractTypeID")]
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }

        private bool _IsLock;
        public static string COL_IsLock = "IsLock";
        [Column(Name = "IsLock")]
        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }

    }
}
