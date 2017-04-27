using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public class CustomerType : EntityBase
    {
        public static string TAB_Name = "CustomerType";

        private int _CustomerTypeID;
        public static string COL_CustomerTypeID = "CustomerTypeID";
        [Keys]
        [Column(Name = "CustomerTypeID")]
        public int CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set { _CustomerTypeID = value; }
        }

        private string _CustomerTypeName;
        public static string COL_CustomerTypeName = "CustomerTypeName";
        [Column(Name = "CustomerTypeName")]
        public string CustomerTypeName
        {
            get { return _CustomerTypeName; }
            set { _CustomerTypeName = value; }
        }
    }
}
