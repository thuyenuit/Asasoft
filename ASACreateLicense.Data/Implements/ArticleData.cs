using ASACreateLicense.Model.Models;
using ASACreateLicense.Model.ViewModels;
using ASALibrary.ASA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASACreateLicense.Data.Implements
{
    public class ArticleData
    {
        private ASABaseContext ctr = new ASABaseContext();

        public IEnumerable<ArticleViewModel> GetAll()
        {
            string sqlString = "exec Article_List";
            IEnumerable<ArticleViewModel> list = ctr.LoadListObjectByStr<ArticleViewModel>(sqlString);
            return list.ToList();
        }

        public Article GetOb(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.ID == id);
            if (result != null)
                return result;
            return null;
        }

        public Article GetByContractType(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.ContractTypeID == id && x.IsLock == false);
            if (result != null)
                return result;
            return null;
        }

        public bool AddArticle(ArticleViewModel articleVM)
        {           
            try
            {
                Article article = new Article()
                {
                    ArticleName = articleVM.ArticleName,
                    Content = articleVM.Content,
                    IsLock = articleVM.IsLock,
                    ContractTypeID = articleVM.ContractTypeID
                };
                ctr.Insert<Article>(article);
                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool UpdateArticle(ArticleViewModel articleVM)
        {
            try
            {                 
                var result = ctr.LoadListObject<Article>().FirstOrDefault(x => x.ID == articleVM.ID);

                if (result != null)
                {
                    result.ArticleName = articleVM.ArticleName;
                    result.Content = articleVM.Content;
                    result.IsLock = articleVM.IsLock;
                    result.ContractTypeID = articleVM.ContractTypeID;
                }
                ctr.Update<Article>(result);
                return true;
            }
            catch
            {
            }
            return false;
        }
    }
}
