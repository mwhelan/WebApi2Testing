using System;
using System.Web;
using System.Web.Http;
using TestableWebApi.Api;

namespace TestableWebApi.Hosts.WebHost
{
    public class WebApiApplication : HttpApplication
    {
        private static readonly ApiApplication WebApiConfig = 
            new ApiApplication(GlobalConfiguration.Configuration);

        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Configure();
        }
    }
}