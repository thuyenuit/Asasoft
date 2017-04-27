using ASACreateLicense.Data.Implements;
using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Service.Services
{
    public class TUserService
    {
        private TUserData _tUserData = new TUserData();

        public IEnumerable<TUserViewModel> GetAll(string keyword)
        {
            return _tUserData.GetAll(keyword);
        }

        public bool SelectByEmail(string email)
        {
            return _tUserData.SelectByEmail(email);
        }

        public bool SelectByUsername(string username)
        {
            return _tUserData.SelectByUsername(username);
        }

        public TUser GetByUsername(string username)
        {
            return _tUserData.GetByUsername(username);
        }

        public bool CheckEmailUserWhenUpdate(string username, string email)
        {
            return _tUserData.CheckEmailUserWhenUpdate(username, email);
        }

        public bool AddUser(TUserViewModel tUserVM)
        {
            return _tUserData.AddUser(tUserVM);
        }

        public bool UpdateUser(TUserViewModel tUserVM)
        {
            return _tUserData.UpdateUser(tUserVM);
        }

        public bool ChangePassword(string userName, string newPassword)
        {
            return _tUserData.ChangePassword(userName, newPassword);
        }

        public async Task<int> GetUserByUsernamePassword(string userName, string newPassword)
        {
            return await _tUserData.GetUserByUsernamePassword(userName, newPassword);
        }
    }
}
