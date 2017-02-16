using System.Web.Mvc;
using BookShop.Web.Common.filters;

namespace BookShop.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
            filters.Add(new HttpStatusCodeFilterAttribute());
        }
    }
}
