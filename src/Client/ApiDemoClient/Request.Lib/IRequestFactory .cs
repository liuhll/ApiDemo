using Request.Lib.Data;
using RestSharp;

namespace Request.Lib
{
    public interface IRequestFactory 
    {
        IRequest Create(string resource, Common.Method method);
        
    }
}