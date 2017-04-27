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
    public class ContractsService
    {
        private ContractsData contractsData = new ContractsData();

        public IEnumerable<ContractsViewModel> GetAll(string keyword, int contracttype, bool isLock)
        {
            return contractsData.GetAll(keyword, contracttype, isLock);
        }

        public ContractsViewModel GetByID(int id)
        {
            return contractsData.GetByID(id);
        }

        public bool CreateContract(ContractsViewModel contractsVM)
        {
            return contractsData.CreateContract(contractsVM);
        }

        public bool UpdateContract(ContractsViewModel contractsVM)
        {
            return contractsData.UpdateContract(contractsVM);
        }

        public Contracts DeleteContracts(int id)
        {
            return contractsData.DeleteContracts(id);
        }
    }
}
