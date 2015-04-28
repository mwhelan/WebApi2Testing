using System;
using System.Net.Http;

namespace TestableWebApi.Tests.Servers
{
    public class WebApiApplicationDriver : IDisposable
    {
        private IApiServer _server;
        public Exception Exception { get; set; }
        public HttpResponseMessage Response { get; set; }

        public WebApiApplicationDriver(IApiServer server)
        {
            _server = server;
        }

        public WebApiApplicationDriver()
        {
            _server = new InMemoryApiServer();
        }

        public virtual void HandleRequest(HttpRequestMessage request)
        {
            try
            {
                var client = new HttpClient(_server.ServerHandler);
                Response = client.SendAsync(request).Result;
            }
            catch (Exception ex)
            {
                Exception = ex;
                if (Exception is NotImplementedException) throw ex;
            }
        }

        public IApiServer Server { get { return _server; }}

        public void Dispose()
        {
            //_server.Dispose();
        }
    }
}
