using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using NUnit.Framework;
using TestableWebApi.Api.Filters;
using TestableWebApi.Tests.Helpers;
using TestableWebApi.Tests.Specify;

namespace TestableWebApi.Tests.Unit.Api.Filters
{
    public class When_a_Post_request_has_an_empty_message_body : SpecificationFor<EmptyParameterFilterAttribute>
    {
        private string _parameterName = "requestModel";
        private HttpActionContext _actionContext;

        public override void InitialiseSystemUnderTest()
        {
            SUT = new EmptyParameterFilterAttribute(_parameterName);
            var request = new HttpRequestMessage();
            _actionContext = ContextUtilities.GetHttpActionContext(request);
            _actionContext.ActionArguments[_parameterName] = null;
        }

        //public void Given_a_Post_request_with_an_empty_message_body()
        //{
        //}

        public void When_the_action_executes()
        {
            SUT.OnActionExecuting(_actionContext);
        }

        public void Then_should_get_a_response()
        {
            Assert.NotNull(_actionContext.Response);
        }

        public void AndThen_the_response_status_code_should_be_400_Bad_Request()
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, _actionContext.Response.StatusCode);
        }
    }
}
