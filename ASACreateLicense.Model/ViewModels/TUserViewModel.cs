using ASACreateLicense.Model.Models;
using ASALibrary.ASA.Domain;

namespace ASACreateLicense.Model.ViewModels
{
    public class TUserViewModel : TUser
    {
        private string _NewPassword;
        public static string COL_NewPassword = "NewPassword";

        [Column(Name = "NewPassword")]
        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; }
        }
    }
}