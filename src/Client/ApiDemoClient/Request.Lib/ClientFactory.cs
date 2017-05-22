using System;
using RestSharp;

namespace Request.Lib
{
    internal class ClientFactory : IClientFactory
    {

        private readonly Uri _baseUri;

        public ClientFactory(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        public ClientFactory(string baseUri)
        {
            _baseUri = new Uri(baseUri);
        }

        public IRestClient Create()
        {
            var client = new RestClient(_baseUri);
            return client;
        }
    }
}