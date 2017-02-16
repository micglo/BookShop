using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Service.Interfaces;

namespace BookShop.Web.Controllers
{
    [RoutePrefix("Wydawnictwo")]
    public class PublishingController : BaseController
    {
        public PublishingController(IPublishingService publishingService)
        {
            PublishingService = publishingService;
        }


        [Route("{name}", Name = "GetPublishing")]
        public async Task<ActionResult> GetPublishing(string name)
        {
            var publishingExists = await PublishingService.Exists(name);
            if (!publishingExists)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(await PublishingService.GetByNameAsync(name));
        }
    }
}