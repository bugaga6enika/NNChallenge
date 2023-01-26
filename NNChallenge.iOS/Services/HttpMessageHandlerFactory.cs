using System;
using System.Net.Http;
using NNChallenge.Interfaces;

namespace NNChallenge.iOS.Services
{
    public class HttpMessageHandlerFactory : IHttpMessageHandlerFactory
    {
        public HttpMessageHandler Create() => new NSUrlSessionHandler();
    }
}

