using System;
using System.Net.Http;

namespace TestableWebApi.Tests.Servers
{
    public interface IApiServer
    {
        Uri BaseAddress { get; }
        ApiServerHost Kind { get; }
        HttpMessageHandler ServerHandler { get; }
        void Start();
        void Stop();
    }
}
