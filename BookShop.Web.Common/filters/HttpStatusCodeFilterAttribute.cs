using System.Net;
using System.Web.Mvc;

namespace BookShop.Web.Common.filters
{
    /// <summary>
    /// Poki co nie uzywany
    /// </summary>
    public class HttpStatusCodeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode == 401)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            else if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else if (filterContext.HttpContext.Response.StatusCode == 404)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }
    }
}