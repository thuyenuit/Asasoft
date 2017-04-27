using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Common;

namespace ASACreateLicense.Data.Implements
{
    public class ContractsData
    {
        private ASABaseContext ctr = new ASABaseContext();

        public IEnumerable<ContractsViewModel> GetAll(string keyword, int contracttype, bool isLock)
        {
            string sqlString = "exec Contracts_List N'" + keyword + "', '" + contracttype + "', '"+ isLock +"'";
            IEnumerable<ContractsViewModel> list = ctr.LoadListObjectByStr<ContractsViewModel>(sqlString);
            return list.ToList();
        }

        public ContractsViewModel GetByID(int id)
        {
            string sqlString = "exec Contracts_ListNoField";
            IEnumerable<ContractsViewModel> list = ctr.LoadListObjectByStr<ContractsViewModel>(sqlString);

            var result = list.FirstOrDefault(x => x.ID == id);
            if (result != null)
                return result;
            return null;
        }

        public bool CreateContract(ContractsViewModel contractsVM)
        {
            try
            {
                Contracts contract = new Contracts()
                {
                    ContractNumber = contractsVM.ContractNumber,
                    ContractName = contractsVM.ContractName,
                    CustomerID = contractsVM.CustomerID,
                    UnitInfoID = contractsVM.UnitInfoID,
                    ContractContent = contractsVM.ContractContent,
                    ContractTime = "1 năm",
                    CreateDate = SystemDefine.SystemDate.Date,
                    Description1 = contractsVM.Description1,
                    Description2 = contractsVM.Description2,
                    CreateBy = "admin",
                    ContractTypeID = contractsVM.ContractTypeID,
                    IsLock = contractsVM.IsLock
                };
                ctr.Insert<Contracts>(contract);

                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool UpdateContract(ContractsViewModel contractsVM)
        {
            //IEnumerable<Contracts> list = GetAll();

            List<Contracts> list = new List<Contracts>();
            list = ctr.LoadListObject<Contracts>();
            var result = list.FirstOrDefault(x => x.ID == contractsVM.ID);

            if (result != null)
            {
                try
                {
                    result.ContractNumber = contractsVM.ContractNumber;
                    result.ContractName = contractsVM.ContractName;
                    result.CustomerID = contractsVM.CustomerID;
                    result.UnitInfoID = contractsVM.UnitInfoID;
                    result.ContractContent = contractsVM.ContractContent;
                    result.Description1 = contractsVM.Description1;
                    result.Description2 = contractsVM.Description2;
                    result.ContractTypeID = contractsVM.ContractTypeID;
                    result.IsLock = contractsVM.IsLock;
                    ctr.Update<Contracts>(result);
                    return true;
                }
                catch(Exception ex)
                {
                    
                }
            }

            return false;
        }

        public Contracts DeleteContracts(int id)
        {
            var result = ctr.LoadListObject<Contracts>().FirstOrDefault(x => x.ID == id && x.IsLock == false);

            if (result != null)
            {
                result.IsLock = true;
                ctr.Update<Contracts>(result);
                return result;
            }

            return null;
        }
    }
}
