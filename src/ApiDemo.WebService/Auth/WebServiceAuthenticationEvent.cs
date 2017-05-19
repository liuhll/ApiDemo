using System;
using System.Web;
using System.Security.Principal;

namespace ApiDemo.WebService.Auth
{
    public class WebServiceAuthenticationEvent : EventArgs
    {
        private IPrincipal _iPrincipalUser;
        private readonly HttpContext _context;
        private string _user;
        private string _password;

        public WebServiceAuthenticationEvent(HttpContext context)
        {
            _context = context;
        }

        public WebServiceAuthenticationEvent(HttpContext context,
            string user, string password)
        {
            _context = context;
            _user = user;
            _password = password;
        }
        public HttpContext Context
        {
            get { return _context; }
        }
        public IPrincipal Principal
        {
            get { return _iPrincipalUser; }
            set { _iPrincipalUser = value; }
        }
        public void Authenticate()
        {
            GenericIdentity i = new GenericIdentity(User);
            this.Principal = new GenericPrincipal(i, new String[0]);
        }
        public void Authenticate(string[] roles)
        {
            GenericIdentity i = new GenericIdentity(User);
            this.Principal = new GenericPrincipal(i, roles);
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public bool HasCredentials
        {
            get
            {
                if ((_user == null) || (_password == null))
                    return false;
                return true;
            }
        }
    }
}