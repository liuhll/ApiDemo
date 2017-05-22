using Request.Lib.Data;
using RestSharp;

namespace Request.Lib
{
    public class RequestFactory : IRequestFactory
    {
        private readonly IClientFactory _clientFactory;

        public RequestFactory(string baseUri)
        {
            _clientFactory = new ClientFactory(baseUri);
        }

        public IRequest Create(string resource, Common.Method method)
        {
            var client = _clientFactory.Create();
            return new Request(resource, method, client);
        }
    }
}