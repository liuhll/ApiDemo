using ApiDemo.Dtos.Base;

namespace ApiDemo.Dtos.Student
{
    public class StudentInput : BasicDto
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        public int Age { get; set; }
    }
}