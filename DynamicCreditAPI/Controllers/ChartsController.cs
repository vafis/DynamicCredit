using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using DynamicCredit.API.ModelView;
using DynamicCredit.DAL;

namespace DynamicCredit.API.Controllers
{
    public class ChartsController:ApiController
    {
        private IDAL _dal;

        public ChartsController(IDAL dal)
        {
            _dal = dal;
        }

        public async Task<HttpResponseMessage> GetWeightedAverage()
        {
            var ret = await _dal.ExecuteCommandAsync("Get_Weighted_Average");
            return Request.CreateResponse(HttpStatusCode.OK, ret);
        }
        public HttpResponseMessage GetChartsData()
        {
            var chartsData=new ChartsData();
            var tasks = new Task<DataTable>[2];
            
            tasks.SetValue(_dal.ExecuteCommandAsync("GetChart1"), 0);
            tasks.SetValue(_dal.ExecuteCommandAsync("GetChart2"), 1);

            Task.Factory.ContinueWhenAll(tasks, (ret) =>
            {
                chartsData.Chart1Data = ret[0].Result;
                chartsData.Chart2Data = ret[1].Result;
            }).Wait();


            return Request.CreateResponse(HttpStatusCode.OK, chartsData);
        }

    }
}
