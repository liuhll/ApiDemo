using System;
using System.Web.Http;
using ApiDemo.Controllers.Base;
using ApiDemo.Core.AppService;
using ApiDemo.Core.Common;
using ApiDemo.Core.Common.Enum;
using ApiDemo.Core.Dao;
using ApiDemo.Core.Entities;
using ApiDemo.Dtos;
using ApiDemo.Dtos.Student;

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

        /// <summary>
        /// 新增一条学信息生
        /// </summary>
        /// <param name="studentInput"></param>
        /// <returns></returns>
        [Route("Student")]
        [HttpPost]
        public ResultMessage<string> AddStudent([FromBody]StudentInput studentInput)
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

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <param name="appId"></param>
        /// <param name="sign"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        [Route("Student")]
        [HttpGet]
        public ResultMessage<StudentOutput> GetStudent(int id, string appId, string sign, string timestamp)
        {
            try
            {
                var student = _studentAppService.Get(id);
                var stuDao = new StudentOutput()
                {
                    Id = student.Id,
                    Age = student.Age,
                    Name = student.Name
                };
                return new ResultMessage<StudentOutput>(stuDao);
            }
            catch (Exception e)
            {
                return new ResultMessage<StudentOutput>(ResultCode.ServiceError,e.Message);
            }
        }

        [Route("Student")]
        [HttpDelete]
        public ResultMessage<string> DelStudent(int id, string appId, string sign, string timestamp)
        {
            try
            {
                var isSuccess = _studentAppService.Delete(id);
                if (isSuccess)
                {
                    return new ResultMessage<string>("删除学生成功");
                }
                else
                {
                    return new ResultMessage<string>(ResultCode.Fail,"删除学生失败");
                }
            }
            catch (Exception e)
            {
                return new ResultMessage<string>(ResultCode.ServiceError, "异常:删除学生失败,原因:" + e.Message);
            }
        }
    }
}
