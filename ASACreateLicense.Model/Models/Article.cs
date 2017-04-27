using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class Article : EntityBase
    {
        public static string TAB_Name = "Article";

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

        private string _Content;
        public static string COL_Content = "Content";
        [Column(Name = "Content")]
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private bool _IsLock;
        public static string COL_IsLock = "IsLock";
        [Column(Name = "IsLock")]
        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }

        private int _ContractTypeID;
        public static string COL_ContractTypeID = "ContractTypeID";
        [Column(Name = "ContractTypeID")]
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }
     
        private string _ArticleName;
        public static string COL_ArticleName = "ArticleName";
        [Column(Name = "ArticleName")]
        public string ArticleName
        {
            get { return _ArticleName; }
            set { _ArticleName = value; }
        }

       

       
       
    }
}
