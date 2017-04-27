using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class StatusLicense : EntityBase
    {
        public static string TAB_Name = "StatusLicense";

        private int _StatusLicenseID;
        public static string COL_StatusLicenseID = "StatusLicenseID";
        [Keys]
        [Column(Name = "StatusLicenseID")]
        public int StatusLicenseID
        {
            get { return _StatusLicenseID; }
            set { _StatusLicenseID = value; }
        }

        private string _StatusLicenseName;
        public static string COL_StatusLicenseName = "StatusLicenseName";
        [Column(Name = "StatusLicenseName")]
        public string StatusLicenseName
        {
            get { return _StatusLicenseName; }
            set { _StatusLicenseName = value; }
        }
    }
}
