using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Models.ViewModels.Books;
using BookShop.Service.Interfaces;
using BookShop.Web.Common.filters;
using BookShop.Web.Controllers;

namespace BookShop.Web.Areas.Admin.Controllers
{
    //[MyAuthorize(Roles = "Admin,Employee")]
    public class BooksController : BaseController
    {
        public BooksController(IBookService bookService)
        {
            BookService = bookService;
        }
        

        public async Task<ActionResult> Index()
            => View(await BookService.GetAll());


        //Do przeladownaia tabeli
        public async Task<ActionResult> IndexPartial()
            => PartialView(await BookService.GetAll());


        public async Task<ActionResult> Create()
            => View(await BookService.GetBookCreateViewModel());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookPostViewModel book)
        {
            if (ModelState.IsValid)
            {
                var newBook = await BookService.Create(book);

                //redirect to widoku szczegółowego książki
                return RedirectToAction("GetSingleBook", "Books", new
                {
                    area = "", mainCategoryName = newBook.MainCategoryName, subMainCategoryName = newBook.SubMainCategoryName,
                    id = newBook.Id, title = newBook.Title
                });
            }
            return View(await BookService.GetBookCreateViewModel());
        }


        public async Task<ActionResult> Edit(int id)
        {
            var bookExists = await BookService.Exists(id);
            if (!bookExists)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(await BookService.GetBookEditViewModel(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BookEditViewModel book)
        {
            var bookExists = await BookService.Exists(book.Id);
            if (!bookExists)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            if (ModelState.IsValid)
            {
                var updatedBook = await BookService.Edit(book);
                return RedirectToAction("GetSingleBook", "Books", new
                {
                    area = "",
                    mainCategoryName = updatedBook.MainCategoryName,
                    subMainCategoryName = updatedBook.SubMainCategoryName,
                    id = updatedBook.Id,
                    title = updatedBook.Title
                });
            }
            return View(await BookService.GetBookEditViewModel(book.Id));
        }


        public async Task<ActionResult> DeleteModal(int id)
            => PartialView(await BookService.GetBookById(id));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteBookPost(int id)
        {
            var result = await BookService.Delete(id);
            return PartialView("_infoPartial", result);
        }


        //Do select listy kategorii najbliższych w zależności od podkategorii
        public async Task<ActionResult> GetBookCategories(string[] subMainCategoryIdList)
        {
            var model = await BookService.GetBookCategories(subMainCategoryIdList);
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> SetBestseller(int id)
        {
            await BookService.SetBestseller(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        public async Task<ActionResult> RemoveBestseller(int id)
        {
            await BookService.RemoveBestseller(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}