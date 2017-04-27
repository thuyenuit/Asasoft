using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.Models
{
    public partial class City : EntityBase
    {
        public static string TAB_Name = "City";

        private string _CityID;
        public static string COL_CityID = "CityID";
        [Keys]
        [Column(Name = "CityID")]
        public string CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }

        private string _CityName;
        public static string COL_CityName = "CityName";
        [Column(Name = "CityName")]
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
    }
}
