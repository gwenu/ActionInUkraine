using ActionInUkraine.Web.Filters;
using System;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ActionInUkraine.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref m_initializer, ref m_isInitialized, ref m_initializerLock);
        }

        private static SimpleMembershipInitializer m_initializer;
        private static object m_initializerLock = new object();
        private static bool m_isInitialized;

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
        }
    }
}