using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo.Core.Common.Exception
{
    public class ApiAuthorizeException : System.Exception
    {
        public ApiAuthorizeException(string excMsg) : base(excMsg)
        {
        }

        public ApiAuthorizeException(string excMsg,System.Exception innerException)
            : base(excMsg,innerException)
        {
        }
    }
}
