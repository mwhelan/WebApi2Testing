using NUnit.Framework;
using TestableWebApi.Tests.Specify;
using TestStack.BDDfy.Configuration;

namespace TestableWebApi.Tests.Unit
{
    using TestStack.BDDfy.Reporters.Html;

    [SetUpFixture]
    public class AssemblySetupFixture
    {
        [SetUp]
        public void InitialiseAppDomain()
        {
            Configurator.BatchProcessors.HtmlReport.Disable();
            Configurator.BatchProcessors.Add(new HtmlReporter(new HtmlReportConfig()));
            Configurator.Scanners.StoryMetadataScanner = () => new SpecStoryMetadataScanner();
        }
    }
}
