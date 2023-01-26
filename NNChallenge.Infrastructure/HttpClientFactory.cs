using System;
using System.Net.Http;
using NNChallenge.Infrastructure.Contracts;
using NNChallenge.Interfaces;

namespace NNChallenge.Infrastructure
{
    internal class HttpClientFactory : IHttpClientFactory
    {
        private readonly IHttpMessageHandlerFactory _httpMessageHandlerFactory;

        public HttpClientFactory(IHttpMessageHandlerFactory httpMessageHandlerFactory)
        {
            _httpMessageHandlerFactory = httpMessageHandlerFactory ?? throw new ArgumentNullException(nameof(httpMessageHandlerFactory));
        }

        public HttpClient Create() => new HttpClient(_httpMessageHandlerFactory.Create());
    }
}