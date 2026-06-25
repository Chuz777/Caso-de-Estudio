using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace casodeestudio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string rutaLogs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "todo-.txt");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(rutaLogs, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("--- La Aplicación ToDo Empresarial ha iniciado con éxito ---");


        }
    }
}
