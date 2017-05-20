using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using ApiDemo.Core.Common;
using ApiDemo.Core.Common.Enum;
using ApiDemo.WebService.Dtos.Basic;
using Autofac;
using System.Web.Services.Protocols;
using ApiDemo.Core.AppService;
using ApiDemo.Core.AppService.WebServiceImpl;
using ApiDemo.WebService.Auth;
using WebAppService = ApiDemo.Core.AppService.WebServiceImpl;


namespace ApiDemo.WebService
{
    /// <summary>
    /// StudentService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {
        private readonly IStudentAppService _studentAppService;

        public Authentication authentication;

        public StudentService()
        {
            _studentAppService = new WebAppService.StudentAppService();
        }

        [WebMethod(Description = "获取学生信息")]
        [SoapHeader("authentication")]//用户身份验证的soap头 
        public ResultMessage<StudentOutput> GetStudent(int id)
        {

            //if (User.IsInRole("Customer"))
            //    return new ResultMessage<StudentOutput>(ResultCode.NotAllowed,"验证失败权限");

            //if (User.Identity.IsAuthenticated)
            //    return  new ResultMessage<StudentOutput>(ResultCode.Success,"Ok",new StudentOutput()
            //    {
            //        Age = 10,
            //        Name = "张三"
            //    });

            var stu = _studentAppService.Get(id);

            return new ResultMessage<StudentOutput>(ResultCode.NotAllowed,"没有权限");
        }

    }
}
