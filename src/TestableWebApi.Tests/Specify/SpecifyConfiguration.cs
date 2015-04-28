//using TestStack.BDDfy.Configuration;
//using TestStack.BDDfy.Processors.Reporters.Html;

//namespace Tests.Core.Specify
//{
//    public static class SpecifyConfiguration
//    {
//        public static void InitializeSpecify()
//        {
//            Configurator.BatchProcessors.HtmlReport.Disable();
//            Configurator.BatchProcessors.Add(new HtmlReporter(new SelenoDesignSpecsHtmlReportConfig()));
//            Configurator.Scanners.StoryMetadataScanner = () => new SpecStoryMetadataScanner();
//        }
//    }
//}
