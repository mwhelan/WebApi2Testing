using TestStack.BDDfy.Reporters.Html;

namespace TestableWebApi.Tests.Unit
{

    public class HtmlReportConfig : DefaultHtmlReportConfiguration
    {
        public override string OutputFileName
        {
            get
            {
                return "UnitTests.html";
            }
        }

        public override string ReportHeader
        {
            get
            {
                return "Testable Web API";
            }
        }

        public override string ReportDescription
        {
            get
            {
                return "Unit Tests";
            }
        }
    }
}