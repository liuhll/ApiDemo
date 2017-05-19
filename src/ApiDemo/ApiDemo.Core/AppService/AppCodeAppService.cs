using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Core.Dao;
using ApiDemo.Core.Entities;

namespace ApiDemo.Core.AppService
{
    public class AppCodeAppService : IAppCodeAppService
    {
        private readonly IAppCodeDao _appCodeDao;

        public AppCodeAppService()
        {
            _appCodeDao = new AppCodeDao();
        }

        public AppCode GetAppCode(string appId)
        {
            return _appCodeDao.GetAppCode(appId);
        }
    }
}

