﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var config=new HttpSelfHostConfiguration("http://localhost:8080");
            config.EnableCors();
            config.Routes.MapHttpRoute(
                "API Defalut", "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );

            using (HttpSelfHostServer server = new HttpSelfHostServer(config)) 
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Web API");
                Console.ReadLine();
            }
        }
    }
}