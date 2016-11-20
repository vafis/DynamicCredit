using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using DynamicCredit.API.Config;

namespace DynamicCredit.API.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");
            RouteConfig.RegisterRoutes(config);
            AutofacWebApi.Setup(config);

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
