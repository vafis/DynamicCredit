using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DynamicCredit.DAL;


namespace DynamicCredit.API.Config
{
    public class AutofacWebApi
    {
        public static void Setup(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DAL.DAL>()
                .As<IDAL>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["DynamicCredit"].ConnectionString)
                .InstancePerRequest();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
