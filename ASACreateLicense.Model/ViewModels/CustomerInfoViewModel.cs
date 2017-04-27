using ASACreateLicense.Model.Models;
using ASALibrary.ASA.Domain;

namespace ASACreateLicense.Model.ViewModels
{
    public class CustomerInfoViewModel : CustomerInfo
    {
        private string _CityName;
        public static string COL_CityName = "CityName";

        [Column(Name = "CityName")]
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
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