using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class TUser : EntityBase
    {
        public static string TAB_Name = "TUser";

        private string _Username;
        public static string COL_Username = "Username";
        [Keys]
        [Column(Name = "Username")]
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _Password;
        public static string COL_Password = "Password";
        [Column(Name = "Password")]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _FullName;
        public static string COL_FullName = "FullName";
        [Column(Name = "FullName")]
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        private string _Email;
        public static string COL_Email = "Email";
        [Column(Name = "Email")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _CellPhone;
        public static string COL_CellPhone = "CellPhone";
        [Column(Name = "CellPhone")]
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }

        private string _Avatar;
        public static string COL_Avatar = "Avatar";
        [Column(Name = "Avatar")]
        public string Avatar
        {
            get { return _Avatar; }
            set { _Avatar = value; }
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
