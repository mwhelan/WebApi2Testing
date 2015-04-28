using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using TestableWebApi.Core.Model;
using TestableWebApi.Infrastructure.Data;

namespace TestableWebApi.Api
{
    public class AutofacContainerBuilder
    {
        private readonly HttpConfiguration _configuration;

        public AutofacContainerBuilder(HttpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterHttpRequestMessage(_configuration);
            builder.Register(c => _configuration.Routes).As<HttpRouteCollection>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterAssemblyTypes(typeof(AutofacContainerBuilder).Assembly)
                .AsImplementedInterfaces();
            builder
                .RegisterAssemblyTypes(typeof(Book).Assembly)
                .AsImplementedInterfaces();
            builder
                .RegisterAssemblyTypes(typeof(InMemoryBookRepository).Assembly)
                .AsImplementedInterfaces();
            //builder.RegisterType<InMemoryBookRepository>().As<IBookRepository>().InstancePerApiRequest();


            var container = builder.Build();
            return container;
        }
    }
}