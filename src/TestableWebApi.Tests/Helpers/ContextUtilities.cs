using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using NSubstitute;

namespace TestableWebApi.Tests.Helpers
{
    public static class ContextUtilities
    {

        public static HttpActionContext GetHttpActionContext(HttpRequestMessage request)
        {

            HttpActionContext actionContext = CreateActionContext(request: request);
            return actionContext;
        }

        public static HttpActionContext CreateActionContext(
            HttpControllerContext controllerContext = null, HttpActionDescriptor actionDescriptor = null, HttpRequestMessage request = null)
        {

            HttpControllerContext controllerCtx = controllerContext ?? CreateControllerContext(request: request);
            HttpActionDescriptor descriptor = actionDescriptor ?? Substitute.For<HttpActionDescriptor>();

            return new HttpActionContext(controllerCtx, descriptor);
        }

        public static HttpControllerContext CreateControllerContext(
            HttpConfiguration configuration = null, IHttpController controller = null, IHttpRouteData routeData = null, HttpRequestMessage request = null)
        {

            HttpConfiguration config = configuration ?? new HttpConfiguration();
            IHttpRouteData route = routeData ?? new HttpRouteData(new HttpRoute());
            HttpRequestMessage req = request ?? new HttpRequestMessage();
            req.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            req.Properties[HttpPropertyKeys.HttpRouteDataKey] = route;

            HttpControllerContext context = new HttpControllerContext(config, route, req);
            if (controller != null)
            {
                context.Controller = controller;
            }
            context.ControllerDescriptor = CreateControllerDescriptor(config);

            return context;
        }

        public static HttpControllerDescriptor CreateControllerDescriptor(HttpConfiguration configuration = null)
        {

            HttpConfiguration config = configuration ?? new HttpConfiguration();
            HttpControllerDescriptor controllerDescriptor = new HttpControllerDescriptor();
            controllerDescriptor.Configuration = configuration;

            return controllerDescriptor;
        }
    }
}
