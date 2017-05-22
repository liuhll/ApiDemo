using System;
using System.Threading.Tasks;
using Request.Lib.Common;
using Request.Lib.Data;
using RestSharp;
using WebApi.Client.Common;
using DataFormat = Request.Lib.Common.DataFormat;
using Method = RestSharp.Method;

namespace Request.Lib
{
    public class Request : IRequest
    {
        private readonly IRestClient _client;
        private readonly IRestRequest _request;

        public Request(string resource, Common.Method method, IRestClient client)
        {
            _client = client;
            switch (method)
            {
                case Common.Method.Delete:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.DELETE);
                    break;
                case Common.Method.Get:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.GET);
                    break;
                case Common.Method.Head:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.HEAD);
                    break;
                case Common.Method.Merge:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.MERGE);
                    break;
                case Common.Method.Options:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.OPTIONS);
                    break;
                case Common.Method.Patch:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.PATCH);
                    break;
                case Common.Method.Post:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.POST);
                    break;
                case Common.Method.Put:
                    _request = new RestSharp.RestRequest(resource, RestSharp.Method.PUT);
                    break;
            }
        }


        private void AddRequestParams(RequestParams requestParams,DataFormat dataFormat)
        {
            if (_request.Method == Method.GET)
            {
                foreach (var item in requestParams.GetValues())
                {
                    _request.AddQueryParameter(item.Key, item.Value.ToString());
                }
            }
            else
            {
                if (dataFormat == DataFormat.Json)
                {
                    _request.AddHeader("Content-type", "application/json");
                    _request.AddJsonBody(requestParams.GetValues());
                }
                else
                {
                    _request.AddHeader("Content-type", "application/xml");
                    _request.AddXmlBody(requestParams.GetValues());
                }
               
            }
        }


        public T Execute<T>(RequestParams requestParams, DataFormat format) where T : new()
        {
            if (requestParams != null)
            {
                AddRequestParams(requestParams, format);
            }

            var response = _client.Execute<T>(_request);

            if (response == null)
            {
                throw new Exception("请求失败");
            }
            return response.Data;
        }
    }
}