using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Tavisca.Assignment.MVC.Store;

namespace Tavisca.Assignment.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static ITodoStore TodoStore;
        public static UnityContainer container = new UnityContainer();

        protected void Application_Start()
        {
            RegisterModules();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            TodoStore = container.Resolve<ITodoStore>();

        }

        void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Add("TodoApp", "SessionBased");
        }

        private static void RegisterModules()
        {
            container.RegisterType<ITodoStore, SessionBasedDataStore>();
        }
    }
}
