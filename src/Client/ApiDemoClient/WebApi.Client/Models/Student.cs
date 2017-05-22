namespace WebApi.Client.Models
{
    public class Student
    {
        /// <summary>
        /// 学号
        /// </summary>
        public int Id { get; set; }

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