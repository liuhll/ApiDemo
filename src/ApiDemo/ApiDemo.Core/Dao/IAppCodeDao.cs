using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Core.Entities;

namespace ApiDemo.Core.Dao
{
    public interface IAppCodeDao
    {
        AppCode GetAppCode(string appId);
    }
}
