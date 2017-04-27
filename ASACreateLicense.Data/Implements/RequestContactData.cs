using ASACreateLicense.Models;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Data.Implements
{
    public class RequestContactData
    {
        ASABaseContext ctr = new ASABaseContext();

        //public void AddContact(RequestContact req)
        //{
        //    RequestContact requestcontact = new RequestContact();
        //    requestcontact.CustomerName = req.CustomerName;
        //    requestcontact.Company = req.Company;
        //    requestcontact.Phone = req.Phone;
        //    requestcontact.Email = req.Email;
        //    requestcontact.Msg = req.Msg;
        //    requestcontact.StatusID = 1;
        //    ctr.Insert<RequestContact>(requestcontact);
        //}
        public List<RequestContact> GetAll()
        {
            var result = ctr.LoadListObject<RequestContact>();
            return result.ToList();
        }
        public List<RequestContact> GetByStatus(bool stauts)
        {         
             var result = ctr.LoadListObjectByStr<RequestContact>("exec RequestContac_Load @keysearch = N'" + stauts + "'");
             return result.ToList();         
        }

        public bool UpdateStatus(int id)
        {
            RequestContact contact = new RequestContact();
            contact.ID = id;
            contact = ctr.GetObject<RequestContact>(contact);
            if (contact != null)
            {
                contact.Status = true;
                ctr.Update<RequestContact>(contact);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            RequestContact contact = new RequestContact();
            contact.ID = id;
            contact = ctr.GetObject<RequestContact>(contact);
            if (contact != null)
            {
                contact.StatusID = 0;
                ctr.Update<RequestContact>(contact);
                return true;
            }

            return false;
        }
    }
}
