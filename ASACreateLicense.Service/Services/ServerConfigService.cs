using ASALibrary.ASA.Common;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Service.Services
{
    public class ServerConfigService
    {
        public bool ServerClient(string servername, string username, string password, string database, string option)
        {
            string strConnect = string.Format("Data Source={0};Initial Catalog={1};user id={2}; password={3};{4}", servername, database, username, password, option);
            //Kiểm tra kết nối đến SQL-SERVER...
            try
            {
                DataContext db = new DataContext(strConnect);
                try
                {
                    SystemDefine.ConnectString = strConnect;
                    db.ExecDataTable("SELECT top 1 * FROM sysObjects", CommandType.Text);
                    ASALibrary.ASA.Controller.ControllerBase.SaveWebConfig("ASAEntities", ASALibrary.ASA.Controller.ControllerBase.EncryptString(strConnect, SystemDefine.PROJECTNAME));
                    SystemDefine.Server = db.cnn.DataSource + " \\ " + db.cnn.Database;
                    var setShift = SystemDefine.SystemShift;
                    SystemDefine.DB = db.cnn.Database;

                    return true;
                }
                catch
                {
                   
                }           
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
