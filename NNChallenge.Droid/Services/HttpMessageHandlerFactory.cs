using System.Net.Http;
using NNChallenge.Interfaces;
using Xamarin.Android.Net;

namespace NNChallenge.Droid.Services
{
    public class HttpMessageHandlerFactory : IHttpMessageHandlerFactory
    {
        public HttpMessageHandler Create() => new AndroidClientHandler();
    }
}