using TestStack.BDDfy.Reporters.Html;

namespace TestableWebApi.Tests.Acceptance
{

    public class AcceptanceTestsHtmlReportConfig : DefaultHtmlReportConfiguration
    {
        public override string OutputFileName
        {
            get
            {
                return "NewsServiceAcceptanceTests.html";
            }
        }

        public override string ReportHeader
        {
            get
            {
                return "News Service";
            }
        }

        public override string ReportDescription
        {
            get
            {
                return "Acceptance Tests";
            }
        }
    }
}