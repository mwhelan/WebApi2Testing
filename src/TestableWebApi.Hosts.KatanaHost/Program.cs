using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;
using TestableWebApi.Api;

namespace TestableWebApi.Hosts.KatanaHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080/";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new KatanaConfiguration();
            var application = new ApiApplication(config);
            app.UseWebApi(config);
        }
    }

    public class KatanaConfiguration : HttpConfiguration
    {
    }
}
