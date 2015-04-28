using System.Web.Http;
using Autofac.Integration.WebApi;

namespace TestableWebApi.Api
{
    public class ApiApplication : IApiApplication
    {
        private readonly HttpConfiguration _configuration;
        public HttpConfiguration Configuration { get { return _configuration; }}

        public ApiApplication(HttpConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public void Start()
        //{
        //    // composition root activites
        //    // set up DI container
        //    // set serialisation settings on configuration object
        //    // set up routes
        //}


        public void Configure()
        {
            ConfigureRoutes();
            ConfigureDependencies();
        }

        private void ConfigureDependencies()
        {
            var container = new AutofacContainerBuilder(_configuration).Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            _configuration.DependencyResolver = resolver;
        }

        private void ConfigureRoutes()
        {
            _configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}