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
    public class ArticleService
    {
        private ArticleData articleData = new ArticleData();

        public IEnumerable<ArticleViewModel> GetAll()
        {
            return articleData.GetAll();
        }

        public bool AddArticle(ArticleViewModel articleVM)
        {
            return articleData.AddArticle(articleVM);
        }

        public bool UpdateArticle(ArticleViewModel articleVM)
        {
            return articleData.UpdateArticle(articleVM);
        }

        public Article GetOb(int id)
        {
            return articleData.GetOb(id);
        }

        public Article GetByContractType(int id)
        {
            return articleData.GetByContractType(id);
        }
    }
}
