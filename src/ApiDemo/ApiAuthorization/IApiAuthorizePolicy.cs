using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDemo.ApiAuthorization
{
    public interface IApiAuthorizePolicy
    {
        bool IsValidTime();

        bool IsLegalSign();
    }
}