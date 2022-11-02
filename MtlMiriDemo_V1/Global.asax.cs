using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace MtlMiriDemo_V1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var logger = GetLogger();

        }
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        public Serilog.ILogger GetLogger()
            {
            return new LoggerConfiguration()
                         
                         .WriteTo.File(path: @"C:\Logs",
                         rollingInterval: RollingInterval.Day,
                         rollOnFileSizeLimit: true,
                         fileSizeLimitBytes: 100000,
                         outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{CorrelationId}] [{Level:u3}] [{Username}] [{Message:lj}{Exception}] {NewLine} ")
                         .Enrich.FromLogContext()
                         .MinimumLevel.Information()
                         .CreateLogger();
            }
        }
}