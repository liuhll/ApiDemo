using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request.Lib;
using Request.Lib.Common;
using Request.Lib.Common.Tools;
using Request.Lib.Data;
using WebApi.Client.Common;
using WebApi.Client.Models;

namespace WebApi.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiAddress = ConfigHelper.GetValuesByKey("apiAddress");

            var requestFactory = new RequestFactory(apiAddress);

            //var result = GetStudent(requestFactory);

            var result = AddStudent(requestFactory);

            Console.WriteLine(result.Msg);
          
            Console.ReadLine();
        }

        private static ResultMessage<string> AddStudent(RequestFactory requestFactory)
        {
            var request = requestFactory.Create("/api/v1/Student", Method.Post);

            var requestParams = new RequestParams();
            requestParams.SetValue("Name","张三");
            requestParams.SetValue("Age",22);
            requestParams.MakeSign();

            var result = request.Execute<ResultMessage<string>>(requestParams,DataFormat.Xml);
            return result;
        }

        private static ResultMessage<Student> GetStudent(RequestFactory requestFactory)
        {
            var request = requestFactory.Create("/api/v1/Student", Method.Get);
            var requestParams = new RequestParams();
            requestParams.SetValue("id", 3);
            requestParams.MakeSign();

            var result = request.Execute<ResultMessage<Student>>(requestParams, DataFormat.Json);
            return result;
        }
    }
}
