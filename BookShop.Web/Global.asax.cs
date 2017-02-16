using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BookShop.Models.ViewModels.ShoppingCart;
using BookShop.Web.Common.ShoppingCart;
using NLog;

namespace BookShop.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(ShoppingCartSession), new ShoppingCartModelBinder());

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "ErrorMessages";
            DefaultModelBinder.ResourceClassKey = "ErrorMessages";
        }

        protected void Application_Error()
        {
            Exception exc = Server.GetLastError();
            if (exc.GetType() != typeof(HttpException))
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                LogEventInfo logInfo = new LogEventInfo();
                logInfo.Properties["ErrorMessage"] = exc.Message;
                logInfo.Properties["InnerErrorMessage"] = exc.InnerException?.Message;
                logInfo.Properties["StackTrace"] = exc.StackTrace;
                logger.Debug(logInfo);
            }
        }
    }
}
