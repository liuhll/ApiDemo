using System.Web.Http;
using ApiDemo.ApiAuthorization;

namespace ApiDemo.Controllers.Base
{
   [DemoApiAuthorize]
    public class V1ControllerBase : ApiController
    {
    }
}
