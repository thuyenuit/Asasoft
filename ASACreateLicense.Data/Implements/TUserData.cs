using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Context;
using ASALibrary.ASA.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASACreateLicense.Data.Implements
{
    public class TUserData
    {
        private ASABaseContext ctr = new ASABaseContext();

        public IEnumerable<TUserViewModel> GetAll(string keyword)
        {
            string sqlString = "exec TUser_List N'" + keyword + "'";
            IEnumerable<TUserViewModel> list = ctr.LoadListObjectByStr<TUserViewModel>(sqlString);
            return list.ToList();
        }

        public bool SelectByEmail(string email)
        {
            List<TUser> list = ctr.LoadListObject<TUser>();
            var result = list.FirstOrDefault(x => x.Email == email);
            if (result != null)
                return true;
            return false;
        }

        public bool CheckEmailUserWhenUpdate(string username, string email)
        {
            string sqlString = "exec TUser_SearchNoUsername '" + username + "'";
            IEnumerable<TUserViewModel> list = ctr.LoadListObjectByStr<TUserViewModel>(sqlString);
            var result = list.FirstOrDefault(x => x.Email == email);
            if (result != null)
            {
                return true;
            }

            return false;
        }

        public bool SelectByUsername(string username)
        {
            List<TUser> list = ctr.LoadListObject<TUser>();
            var result = list.FirstOrDefault(x => x.Username == username);
            if (result != null)
                return true;
            return false;
        }

        public TUser GetByUsername(string username)
        {
            List<TUser> list = ctr.LoadListObject<TUser>();
            var result = list.FirstOrDefault(x => x.Username == username);
            if (result != null)
                return result;
            return null;
        }


        public bool AddUser(TUserViewModel tUserVM)
        {
            string strAvatar = tUserVM.Avatar;

            if (tUserVM.Avatar == null)
                strAvatar = "/UploadFiles/images/default.png";
            try
            {
                TUser user = new TUser()
                {
                    Username = tUserVM.Username,
                    FullName = tUserVM.FullName,
                    Email = tUserVM.Email,
                    CellPhone = tUserVM.CellPhone,
                    Avatar = strAvatar,
                    Password = "@123",
                    IsLock = tUserVM.IsLock,
                };
                ctr.Insert<TUser>(user);
             
                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool UpdateUser(TUserViewModel tUserVM)
        {
            TUser user = GetByUsername(tUserVM.Username);
            if (user != null)
            {
                string strAvatar = tUserVM.Avatar;

                if (tUserVM.Avatar == null)
                    strAvatar = "/UploadFiles/images/default.png";
                try
                {
                    user.FullName = tUserVM.FullName;
                    user.Email = tUserVM.Email;
                    user.CellPhone = tUserVM.CellPhone;
                    user.Avatar = strAvatar;
                    user.IsLock = tUserVM.IsLock;
                    ctr.Update<TUser>(user);
                   
                    return true;
                }
                catch
                {
                }
            }      
            return false;
        }

        public bool ChangePassword(string userName, string newPassword)
        {
            var result = GetByUsername(userName);
            if (result != null)
            {
                result.Password = ControllerBase.EncryptString(newPassword, userName);
                ctr.Update<TUser>(result);
                return true;
            }
            return false;
        }


        public async Task<int> GetUserByUsernamePassword(string userName, string newPassword)
        {
            var result = GetByUsername(userName);
            if (result != null)
            {
                if (result.IsLock == true)
                {
                    return 1;
                }

                string password = ControllerBase.EncryptString(newPassword, userName);
                if (password == result.Password)
                    return 0;
                return -1 ;
            }
            return -1;
        }
    }
}