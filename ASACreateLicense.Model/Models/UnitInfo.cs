using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class UnitInfo : EntityBase
    {
        public static string TAB_Name = "UnitInfo";

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

        private string _UnitName;
        public static string COL_UnitName = "UnitName";
        [Column(Name = "UnitName")]
        public string UnitName
        {
            get { return _UnitName; }
            set { _UnitName = value; }
        }


        private string _UnitAddress;
        public static string COL_UnitAddress = "UnitAddress";
        [Column(Name = "UnitAddress")]
        public string UnitAddress
        {
            get { return _UnitAddress; }
            set { _UnitAddress = value; }
        }

        private string _UnitPhone;
        public static string COL_UnitPhone = "UnitPhone";
        [Column(Name = "UnitPhone")]
        public string UnitPhone
        {
            get { return _UnitPhone; }
            set { _UnitPhone = value; }
        }

        private string _UnitFax;
        public static string COL_UnitFax = "UnitFax";
        [Column(Name = "UnitFax")]
        public string UnitFax
        {
            get { return _UnitFax; }
            set { _UnitFax = value; }
        }

        private string _UnitRepresented;
        public static string COL_UnitRepresented = "UnitRepresented";
        [Column(Name = "UnitRepresented")]
        public string UnitRepresented
        {
            get { return _UnitRepresented; }
            set { _UnitRepresented = value; }
        }

        private string _UnitPosition;
        public static string COL_UnitPosition = "UnitPosition";
        [Column(Name = "UnitPosition")]
        public string UnitPosition
        {
            get { return _UnitPosition; }
            set { _UnitPosition = value; }
        }

        private string _UnitTaxCode;
        public static string COL_UnitTaxCode = "UnitTaxCode";
        [Column(Name = "UnitTaxCode")]
        public string UnitTaxCode
        {
            get { return _UnitTaxCode; }
            set { _UnitTaxCode = value; }
        }

        private string _UnitAccountBank;
        public static string COL_UnitAccountBank = "UnitAccountBank";
        [Column(Name = "UnitAccountBank")]
        public string UnitAccountBank
        {
            get { return _UnitAccountBank; }
            set { _UnitAccountBank = value; }
        }

        private string _UnitBank;
        public static string COL_UnitBank = "UnitBank";
        [Column(Name = "UnitBank")]
        public string UnitBank
        {
            get { return _UnitBank; }
            set { _UnitBank = value; }
        }
    }
}
