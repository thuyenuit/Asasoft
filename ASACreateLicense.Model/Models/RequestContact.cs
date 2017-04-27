using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Models
{
	public partial class RequestContact : EntityBase
	{
		public static string TAB_Name = "RequestContact";

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

		private string _Phone;
		public static string COL_Phone = "Phone";
		[Column(Name = "Phone")]
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		private string _Email;
		public static string COL_Email = "Email";
		[Column(Name = "Email")]
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		private string _Msg;
		public static string COL_Msg = "Msg";
		[Column(Name = "Msg")]
		public string Msg
		{
			get { return _Msg; }
			set { _Msg = value; }
		}

		private int _StatusID;
		public static string COL_StatusID = "StatusID";
		[Column(Name = "StatusID")]
		public int StatusID
		{
			get { return _StatusID; }
			set { _StatusID = value; }
		}

		private string _UserReaded;
		public static string COL_UserReaded = "UserReaded";
		[Column(Name = "UserReaded")]
		public string UserReaded
		{
			get { return _UserReaded; }
			set { _UserReaded = value; }
		}

        private bool _Status;
        public static string COL_Status = "Status";
        [Column(Name = "Status")]
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
		
	}
}