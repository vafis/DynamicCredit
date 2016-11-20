using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DynamicCredit.API.Config;
using DynamicCredit.API.ModelView;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Extensions;

namespace DynamicCredit.API.Tests
{
    public class UnitTestAPI
    {
        [Theory]
        [InlineData("http://localhost:8080/api/Charts/GetChartsData/")]
        public async void API_GetChartsData_Test(string url)
        {
            var config = new HttpConfiguration();
            RouteConfig.RegisterRoutes(config);
            AutofacWebApi.Setup(config);
            var httpServer = new HttpServer(config);

            var client = HttpClientFactory.Create(innerHandler: httpServer);
            var response = client.GetAsync(new Uri(url)).Result;
            //HttpResponseMessage response = await client.GetAsync(new Uri(url));


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var viewModel = json.ToObject<ChartsData>();
            Assert.IsType(typeof(ChartsData), viewModel);


        }
    }
}
