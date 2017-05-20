using System;
using System.Web.Http;
using ApiDemo.Controllers.Base;
using ApiDemo.Core.AppService;
using ApiDemo.Core.Common;
using ApiDemo.Core.Common.Enum;
using ApiDemo.Core.Entities;
using ApiDemo.Dtos;

namespace ApiDemo.Controllers.V1
{
    [RoutePrefix("api/v1")]
    public class StudentController : V1ControllerBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        [Route("Student")]
        [HttpPost]
        public ResultMessage<string> Student([FromBody]StudentInput studentInput)
        {
            try
            {
                // :todo 使用AutoMapper可以更方便的将Dto对象与实体对象进行转换
                var student = new Student()
                {
                    Age = studentInput.Age,
                    Name = studentInput.Name

                };
                if (_studentAppService.Insert(student))
                {
                    return new ResultMessage<string>("新增成功");
                }
                return new ResultMessage<string>(ResultCode.Fail, "新增失败");
            }
            catch (Exception ex)
            {

                return new ResultMessage<string>(ResultCode.ServiceError, "异常:" + ex.Message);
            }
        }
    }
}
