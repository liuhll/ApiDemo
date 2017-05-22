using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Client.localhost;

namespace WebService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            Authentication a = new Authentication();
            //a.User = "张三";
            //a.Password = "121234";

            studentService.AuthenticationValue = a;

            var result = studentService.GetStudent(2);

            Console.WriteLine(result.Msg);
        }
    }
}
