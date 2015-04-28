using Autofac;
using NUnit.Framework;
using TestableWebApi.Tests.Servers;
using TestableWebApi.Tests.Specify;
using TestStack.BDDfy.Configuration;

namespace TestableWebApi.Tests.Acceptance
{
    using TestStack.BDDfy.Reporters.Html;

    [SetUpFixture]
    public class AssemblySetupFixture
    {
        private static IApiServer _server { get; set; }

        [SetUp]
        public void SetUpTestEnvironment()
        {
            ConfigureBddfy();
            _server = new InMemoryApiServer();
            var container = BuildContainer();
            ContainerRegistry.Register(container);
            _server.Start();
        }

        [TearDown]
        public void TearDown()
        {
            _server.Stop();
            ContainerRegistry.Get().Dispose();
        }
        
        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(_server).As<IApiServer>().SingleInstance();
            builder.RegisterType<WebApiApplicationDriver>();
            return builder.Build();
        }

        private void ConfigureBddfy()
        {
            Configurator.Scanners.StoryMetadataScanner = () => new StoryMetadataScanner();
            Configurator.BatchProcessors.HtmlReport.Disable();
            Configurator.BatchProcessors.Add(new HtmlReporter(new AcceptanceTestsHtmlReportConfig()));
        }
    }
}
