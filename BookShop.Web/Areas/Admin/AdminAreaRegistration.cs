using System.Web.Mvc;

namespace BookShop.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminRoute",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { "BookShop.Web.Areas.Admin.Controllers" }
            );
        }
    }
}