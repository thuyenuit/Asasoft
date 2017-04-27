using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Common;
using ASALibrary.ASA.Context;
using ASALibrary.ASA.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Data.Implements
{
    public class LicenseInfoData
    {
        ASABaseContext ctr = new ASABaseContext();
        public IEnumerable<LicenseInfoViewModel> GetAll(
            DateTime fromCreateDate, DateTime toCreateDate, DateTime fromEndDate, DateTime toEndDate,
            int statusId, string keyword, int contractId, int viewAll)
        {
            string abc = ControllerBase.DecryptString("GeQhe4O7H256z4qIThQ2OxGg3YI013bGBLNLHqQB+uo=", "admin");

            if (viewAll == 1)
            {
                return GetLicenseNotified();
            }

            string sqlString = string.Empty;
            string fromCreate = string.Empty;
            string toCreate = string.Empty;
            string fromEnd = string.Empty;
            string toEnd = string.Empty;

            string fromCD = fromCreateDate.Date.ToString();
            if (fromCD == "01/01/1900 00:00:00")
                fromCD = "";
            string toCD = toCreateDate.Date.ToString();
            if (toCD == "01/01/1900 00:00:00")
                toCD = "";
            string fromED = fromEndDate.Date.ToString();
            if (fromED == "01/01/1900 00:00:00")
                fromED = "";
            string toED = toEndDate.Date.ToString();
            if (toED == "01/01/1900 00:00:00")
                toED = "";

            if ((string.IsNullOrEmpty(fromCD) && string.IsNullOrEmpty(toCD))
                && (string.IsNullOrEmpty(fromED) && string.IsNullOrEmpty(toED)))
            {
                sqlString = "exec LicenseInfo_List '" + fromCD + "', '" + fromCD + "', '" + fromCD + "', '" + fromCD + "', '" + statusId + "', N'" + keyword + "', '" + contractId + "'";
            }

            if ((!string.IsNullOrEmpty(fromCD) && !string.IsNullOrEmpty(toCD))
                && (string.IsNullOrEmpty(fromED) && string.IsNullOrEmpty(toED)))
            {
                fromCreate = fromCreateDate.ToString(SystemFormatString.SQLDate);
                toCreate = toCreateDate.ToString(SystemFormatString.SQLDate);
                sqlString = "exec LicenseInfo_List '" + fromCreate + "', '" + toCreate + "', '" + fromED + "', '" + fromED + "', '" + statusId + "', N'" + keyword + "', '" + contractId + "'";
            }

            if ((string.IsNullOrEmpty(fromCD) && string.IsNullOrEmpty(toCD))
                && (!string.IsNullOrEmpty(fromED) && !string.IsNullOrEmpty(toED)))
            {
                fromEnd = fromEndDate.ToString(SystemFormatString.SQLDate);
                toEnd = toEndDate.ToString(SystemFormatString.SQLDate);
                sqlString = "exec LicenseInfo_List '" + fromCD + "', '" + fromCD + "', '" + fromEnd + "', '" + toEnd + "', '" + statusId + "', N'" + keyword + "', '" + contractId + "'";
            }

            if ((!string.IsNullOrEmpty(fromCD) && !string.IsNullOrEmpty(toCD))
                && (!string.IsNullOrEmpty(fromED) && !string.IsNullOrEmpty(toED)))
            {
                fromCreate = fromCreateDate.ToString(SystemFormatString.SQLDate);
                toCreate = toCreateDate.ToString(SystemFormatString.SQLDate);
                fromEnd = fromEndDate.ToString(SystemFormatString.SQLDate);
                toEnd = toEndDate.ToString(SystemFormatString.SQLDate);
                sqlString = "exec LicenseInfo_List '" + fromCreate + "', '" + toCreate + "', '" + fromEnd + "', '" + toEnd + "', '" + statusId + "', N'" + keyword + "', '" + contractId + "'";
            }

            IEnumerable<LicenseInfoViewModel> list = ctr.LoadListObjectByStr<LicenseInfoViewModel>(sqlString);
            return list.ToList();
        }

        public IEnumerable<LicenseInfoViewModel> GetLicenseNotified()
        {
            string sqlString = string.Empty;
            DateTime today = SystemDefine.SystemDate.Date;
            sqlString = "exec License_Notified '" + today.ToString(SystemFormatString.SQLDate) + "'";
            IEnumerable<LicenseInfoViewModel> list = ctr.LoadListObjectByStr<LicenseInfoViewModel>(sqlString);

            int thongSo = 30; // tạm thời
            int daysLeft;
            foreach (var item in list)
            {
                daysLeft = (item.EndDate - today).Days;
                if (daysLeft <= thongSo)
                    item.Limit = true;
                else
                    item.Limit = false;
            }
            return list.ToList();
        }

        public LicenseInfo GetAllById(int id)
        {
            string sqlString = "exec LicenseInfo_SearchById '" + id + "'";
            IEnumerable<LicenseInfoViewModel> list = ctr.LoadListObjectByStr<LicenseInfoViewModel>(sqlString);

            var result = list.FirstOrDefault(x => x.LicenseID == id);
            if (result != null)
                return result;
            return null;
        }

        public LicenseInfo DeleteLicenseInfo(int id)
        {
            var result = ctr.LoadListObject<LicenseInfo>().FirstOrDefault(x => x.LicenseID == id);

            if (result != null)
            {
                result.StatusLicenseID = 3;
                ctr.Update<LicenseInfo>(result);
                return result;
            }

            return null;
        }

    }
}
