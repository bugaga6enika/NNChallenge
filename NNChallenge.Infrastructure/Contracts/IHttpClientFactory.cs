using System;
using System.Net.Http;

namespace NNChallenge.Infrastructure.Contracts
{
    internal interface IHttpClientFactory
    {
        public HttpClient Create();
    }
}

