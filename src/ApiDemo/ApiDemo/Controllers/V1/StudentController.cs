using System;
using System.Web.Http;
using ApiDemo.Controllers.Base;
using ApiDemo.Core.AppService;
using ApiDemo.Core.Entities;
using ApiDemo.Dtos;

namespace ApiDemo.Controllers.V1
{
    [System.Web.Http.RoutePrefix("api/v1")]
    public class StudentController : V1ControllerBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        [System.Web.Http.Route("Student")]
        [System.Web.Http.HttpPost]
        public string Student([FromBody]StudentInput studentInput)
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
                    return "新增成功";
                }
                return "新增失败";
            }
            catch (Exception ex)
            {

                return "异常:" + ex.Message;
            }
        }
    }
}
