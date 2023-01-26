using System.Net.Http;

namespace NNChallenge.Interfaces
{
    public interface IHttpMessageHandlerFactory
    {
        public HttpMessageHandler Create();
    }
}