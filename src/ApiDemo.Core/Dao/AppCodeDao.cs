using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Core.Entities;
using ApiDemo.Core.EntityFramework;

namespace ApiDemo.Core.Dao
{
    public class AppCodeDao : IAppCodeDao
    {
        public AppCode GetAppCode(string appId)
        {
            using (var ctx = new DemoContext())
            {
                return ctx.AppCodes.First(p=>p.AppId == appId);
            }
        }
    }
}
