using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASACreateLicense.Data.Implements;
using ASACreateLicense.Models;

namespace ASACreateLicense.Service.Services
{
    public class RequestContactService
    {
        ASABaseContext ctr = new ASABaseContext();
        RequestContactData requestContactData = new RequestContactData();

        public List<RequestContact> GetAll()
        {
            return requestContactData.GetAll();
        }

        public List<RequestContact> GetAll(bool status)
        {
            return requestContactData.GetByStatus(status);
        }

        public bool UpdateStatus(int id)
        {
            return requestContactData.UpdateStatus(id);
        }

        public bool Delete(int id)
        {
            return requestContactData.Delete(id);
        }
    }
}
