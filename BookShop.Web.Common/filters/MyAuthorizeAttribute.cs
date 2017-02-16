using System.Web.Mvc;
using System.Web.Routing;

namespace BookShop.Web.Common.filters
{
    /// <summary>
    /// Filtr autoryzacji
    /// </summary>
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                     new RouteValueDictionary(
                         new
                         {
                             controller = "Error",
                             action = "Forbidden"
                         })
                     );
                filterContext.Result = new HttpStatusCodeResult(403);

            }
            else
            {
                var returnUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
                filterContext.Result = new RedirectToRouteResult(
                     new RouteValueDictionary(
                         new
                         {
                             controller = "Account",
                             action = "Login",
                             returnUrl
                         })
                     );
            }
        }
    }
}
