using SclBaseball.Data;
using System;
using System.Data.Entity.Infrastructure.Interception;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SclBaseball
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbInterception.Add(new GameInterceptorTransientErrors());
            DbInterception.Add(new GameInterceptorLogging());

            /*  You can add interceptors using the DbInterception.Add method anywhere in your code; it doesn't have to be in the Application_Start method. 
             *  Another option is to put this code in the DbConfiguration class that you created earlier to configure the execution policy.
             *  Ex: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/connection-resiliency-and-command-interception-with-the-entity-framework-in-an-asp-net-mvc-application
             */

            //Database.SetInitializer<Data.GameContext>(new CreateDatabaseIfNotExists<Data.GameContext>());
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("Server");
        }
    }
}
