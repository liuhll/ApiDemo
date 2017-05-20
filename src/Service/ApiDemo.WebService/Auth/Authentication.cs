using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace ApiDemo.WebService.Auth
{
    public class Authentication : SoapHeader
    {
        public string User;
        public string Password;
    }
}