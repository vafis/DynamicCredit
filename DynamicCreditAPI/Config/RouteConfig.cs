﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DynamicCredit.API.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            var routes = config.Routes;
            routes.MapHttpRoute( name: "API Default",
                                 routeTemplate: "api/{controller}/{action}/{id}",
                                 defaults: new { id = RouteParameter.Optional }
                                );


        }
    }
}
