using System.Threading.Tasks;
using Request.Lib.Common;
using Request.Lib.Data;
using WebApi.Client.Common;

namespace Request.Lib
{
    public interface IRequest
    {

        //void AddRequestParams(RequestParams requestParams);

        T Execute<T>(RequestParams requestParams, DataFormat format) where T : new();
          

    }
}