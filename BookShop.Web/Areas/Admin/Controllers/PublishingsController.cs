using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Service.Interfaces;
using BookShop.Web.Common.filters;
using BookShop.Web.Controllers;

namespace BookShop.Web.Areas.Admin.Controllers
{
    //[MyAuthorize(Roles = "Admin,Employee")]
    public class PublishingsController : BaseController
    {
        public PublishingsController(IPublishingService publishingService)
        {
            PublishingService = publishingService;
        }


        public async Task<ActionResult> Index()
            => View(await PublishingService.GetAll());


        //Do przeladownaia tabeli
        public async Task<ActionResult> IndexPartial()
            => PartialView(await PublishingService.GetAll());


        public ActionResult CreateModal()
            => PartialView(new Publishing());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePublishingPost([Bind(Include = "Name,NameForDisplay,Image,Description")] Publishing publishing)
        {
            var result = await PublishingService.Create(publishing);
            return PartialView("_infoPartial", result);
        }


        public async Task<ActionResult> EditModal(int id)
            => PartialView(await PublishingService.GetById(id));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPublishingPost([Bind(Include = "Id,Name,NameForDisplay,Image,Description")] Publishing publishing)
        {
            var result = await PublishingService.Edit(publishing);
            return PartialView("_infoPartial", result);
        }


        //Do wyświetlenia zmiany w tabeli
        public async Task<ActionResult> GetPublishingData(int id)
        {
            var publishing = await PublishingService.GetById(id);
            var model = new
            {
                NameForDisplay = publishing.NameForDisplay
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> DeleteModal(int id)
            => PartialView(await PublishingService.GetById(id));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePublishingPost(int id)
        {
            var result = await PublishingService.Delete(id);
            return PartialView("_infoPartial", result);
        }


        //Do select listy 
        public async Task<ActionResult> GetPublishingsForSelect(string searchString)
        {
            var model = await PublishingService.GetPublishingsForSelect(searchString);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}