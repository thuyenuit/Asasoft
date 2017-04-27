using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class ContractType : EntityBase
    {
        public static string TAB_Name = "ContractType";

        private int _ContractTypeID;
        public static string COL_ContractTypeID = "ContractTypeID";
        [Keys]
        [Column(Name = "ContractTypeID")]
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }

        private string _ContractTypeName;
        public static string COL_ContractTypeName = "ContractTypeName";
        [Column(Name = "ContractTypeName")]
        public string ContractTypeName
        {
            get { return _ContractTypeName; }
            set { _ContractTypeName = value; }
        }
    }
}
