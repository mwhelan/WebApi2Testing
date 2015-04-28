using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using TestableWebApi.Api.Handlers;
using TestableWebApi.Tests.Helpers;
using TestableWebApi.Tests.Specify;

namespace TestableWebApi.Tests.Unit.Api.MessageHandlers
{
    public abstract class RequireHttpsMessageHanderSpecification : SpecificationFor<RequireHttpsMessageHandler>
    {
        protected HttpRequestMessage _request;
        protected HttpResponseMessage _response;

        public async Task When_request_is_handled()
        {
            _response = await SUT.InvokeAsync(_request);
        }
    }

    public class when_request_is_not_over_https : RequireHttpsMessageHanderSpecification
    {

        public void Given_a_standard_request()
        {
            _request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080");
        }

        public void Then_response_should_have_HttpStatusCode_of_Forbidden()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }

    public class when_request_is_over_https : RequireHttpsMessageHanderSpecification
    {

        public void Given_an_https_request()
        {
            _request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:8080");
        }

        public void Then_response_should_have_HttpStatusCode_of_OK()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }

}
