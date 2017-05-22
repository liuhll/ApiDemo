using System;
using System.Web.Services;
using ApiDemo.Core.Common;
using ApiDemo.Core.Common.Enum;
using ApiDemo.WebService.Dtos.Basic;
using System.Web.Services.Protocols;
using ApiDemo.Core.AppService;
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

            //可以通过存储在数据库中的用户与密码来验证
            try
            {
                if (authentication.User.Equals("demoapi") & authentication.Password.Equals("demoapi"))
                {

                    var student = _studentAppService.Get(id);
                    return new ResultMessage<StudentOutput>(new StudentOutput()
                    {
                        Id = student.Id,
                        Age = student.Age,
                        Name = student.Name
                    });
                }
                else
                {
                    return new ResultMessage<StudentOutput>(ResultCode.Fail, "对不起，您没有权限调用此服务！");
                }
            }
            catch (Exception e)
            {
                return new ResultMessage<StudentOutput>(ResultCode.ServiceError, "服务器异常" + e.Message);
            }

        }

    }
}
