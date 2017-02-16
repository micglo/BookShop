using System.Web.Mvc;

namespace BookShop.Web.Controllers
{
    [RoutePrefix("Blad")]
    public class ErrorController : Controller
    {
        [Route("~/DostepZabroniony", Name = "Forbidden")]
        public ActionResult Forbidden()
            => View();


        [Route("~/ZleZapytanie", Name = "BadRequest")]
        public ActionResult BadRequest()
            => View();


        [Route("~/NieZnalezionoStrony", Name = "PageNotFoud")]
        public ActionResult PageNotFoud()
            => View();


        [Route("~/BladSerwera", Name = "ServerError")]
        public ActionResult ServerError()
            => View();
    }
}