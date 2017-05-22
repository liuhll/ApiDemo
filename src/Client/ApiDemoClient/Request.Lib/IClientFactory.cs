using RestSharp;

namespace Request.Lib
{
    public interface IClientFactory
    {
        IRestClient Create();
    }
}