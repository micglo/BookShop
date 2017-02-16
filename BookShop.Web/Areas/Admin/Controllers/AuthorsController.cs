using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Service.Interfaces;
using BookShop.Web.Common.filters;
using BookShop.Web.Controllers;

namespace BookShop.Web.Areas.Admin.Controllers
{
    //[MyAuthorize(Roles = "Admin,Employee")]
    public class AuthorsController : BaseController
    {
        public AuthorsController(IAuthorService authorService)
        {
            AuthorService = authorService;
        }

        public async Task<ActionResult> Index()
            => View(await AuthorService.GetAll());


        //Widok do przeladowania tabeli
        public async Task<ActionResult> IndexPartial()
            => PartialView(await AuthorService.GetAll());


        public ActionResult CreateModal()
            => PartialView(new Author());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAuthorPost([Bind(Include = "FirstName,LastName,LastNameForDisplay,Description")] Author author)
        {
            var result = await AuthorService.Create(author);
            return PartialView("_infoPartial", result);
        }


        public async Task<ActionResult> EditModal(int id)
            => PartialView(await AuthorService.GetById(id));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAuthorPost([Bind(Include = "Id,FirstName,LastName,LastNameForDisplay,Description")] Author author)
        {
            var result = await AuthorService.Edit(author);
            return PartialView("_infoPartial", result);
        }


        //Do updatu tabeli po edycji
        public async Task<ActionResult> GetAuthorData(int id)
        {
            var author = await AuthorService.GetById(id);
            var model = new
            {
                FirstName = author.FirstName,
                LastNameForDisplay = author.LastNameForDisplay
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> DeleteModal(int id)
            => PartialView(await AuthorService.GetById(id));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAuthorPost(int id)
        {
            var result = await AuthorService.Delete(id);
            return PartialView("_infoPartial", result);
        }


        //Autorzy do selectListy
        public async Task<ActionResult> GetAuthorsForSelect(string searchString)
        {
            var model = await AuthorService.GetAuthorsForSelect(searchString);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}