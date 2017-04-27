using ASACreateLicense.Model.Models;
using ASALibrary.ASA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Model.ViewModels
{
    public class ArticleViewModel : Article
    {
        private string _ContractTypeName;
        public static string COL_ContractTypeName = "ContractTypeName";
        [Column(Name = "ContractTypeName")]
        public string ContractTypeName
        {
            get { return _ContractTypeName; }
            set { _ContractTypeName = value; }
        }
    }
}
