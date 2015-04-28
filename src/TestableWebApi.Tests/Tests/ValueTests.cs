using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using TestableWebApi.Tests.Servers;

namespace TestableWebApi.Tests.Tests
{
    public abstract class ValueTests
    {
        private readonly IApiServer _server;
        private const string _relativeUrl = "api/values";
        public ValueTests(IApiServer server)
        {
            _server = server;
        }
        [Test]
        public void GetAllValuesReturnsSuccessfulStatusCode()
        {
            var valuesUri = new Uri(_server.BaseAddress, _relativeUrl);
            using (var client = new HttpClient(_server.ServerHandler))
            {
                HttpResponseMessage httpResponseMessage = 
                    client.GetAsync(valuesUri).Result;
                Assert.That(httpResponseMessage.IsSuccessStatusCode);
                Assert.That(httpResponseMessage.StatusCode, 
                    Is.EqualTo(HttpStatusCode.OK));
            }
        }
        [SetUp]
        public void SetUp()
        {
            _server.Start();
        }
        [TearDown]
        public void TearDown()
        {
            _server.Stop();
        }
    }
}
