using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Models.QueryString;
using BookShop.Service.Interfaces;

namespace BookShop.Web.Controllers
{
    [RoutePrefix("Kategoria")]
    public class BooksController : BaseController
    {
        public BooksController(IBookService bookService)
        {
            BookService = bookService;
        }



        [Route("~/Szukaj", Name = "GetBooksBySearchString")]
        public async Task<ActionResult> GetBooksBySearchString(QueryStringSearch queryModel)
            => View(await BookService.GetBooksBySearchString(queryModel));



        [Route("~/Szukaj/{searchString}/{searchOption}/{page}/{itemsPerPage}/{sortOrder}", Name = "GetBooksBySearchStringPartial")]
        public async Task<PartialViewResult> GetBooksBySearchStringPartial(QueryStringSearch queryModel)
            => PartialView(await BookService.GetBooksBySearchString(queryModel));



        [Route("{mainCategoryName}", Name = "GetBooksByMainCategory")]
        public async Task<ActionResult> GetBooksByMainCategory(string mainCategoryName)
        {
            if (await BookService.BadRequest(mainCategoryName))
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(await BookService.GetBooksForMainCategory(mainCategoryName));
        }



        [Route("{mainCategory}/{subMainCategory}", Name = "GetBooksBySubMainCategory")]
        public async Task<ActionResult> GetBooksBySubMainCategory(QueryStringBooks queryModel)
        {
            if (await BookService.BadRequest(queryModel.MainCategory, queryModel.SubMainCategory))
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(await BookService.GetBooksForSubMainCategory(queryModel.MainCategory,
                queryModel.SubMainCategory, queryModel.Page, queryModel.ItemsPerPage, queryModel.SortOrder));
        }



        [Route("{mainCategory}/{subMainCategory}/{bookCategory}", Name = "GetBooksByBookCategory")]
        public async Task<ActionResult> GetBooksByBookCategory(QueryStringBooks queryModel)
        {
            if (await BookService.BadRequest(queryModel.MainCategory, queryModel.SubMainCategory, queryModel.BookCategory))
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(await BookService.GetBooksForBookCategory(queryModel.MainCategory, queryModel.SubMainCategory, queryModel.BookCategory,
                queryModel.Page, queryModel.ItemsPerPage, queryModel.SortOrder));
        }



        [Route("~/Produkt/{mainCategoryName}/{subMainCategoryName}/{id:int}/{title}", Name = "GetSingleBook")]
        public async Task<ActionResult> GetSingleBook(string mainCategoryName, string subMainCategoryName, int id,
            string title)
        {
            if (await BookService.BadRequest(mainCategoryName, subMainCategoryName))
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(await BookService.GetById(id));
        }



        [Route("{mainCategory}/{subMainCategory}/{page}/{itemsPerPage}/{sortOrder}",
            Name = "GetBooksBySubMainCategoryPartial")]
        public async Task<ActionResult> GetBooksBySubMainCategoryPartial(QueryStringBooks queryModel)
        {
            if (await BookService.BadRequest(queryModel.MainCategory, queryModel.SubMainCategory))
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return PartialView(await BookService.GetBooksForSubMainCategory(queryModel.MainCategory,
                queryModel.SubMainCategory, queryModel.Page, queryModel.ItemsPerPage, queryModel.SortOrder));
        }



        [Route("{mainCategory}/{subMainCategory}/{bookCategory}/{page}/{itemsPerPage}/{sortOrder}",
            Name = "GetBooksByBookCategoryPartial")]
        public async Task<ActionResult> GetBooksByBookCategoryPartial(QueryStringBooks queryModel)
        {
            if (await BookService.BadRequest(queryModel.MainCategory, queryModel.SubMainCategory, queryModel.BookCategory))
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return PartialView(await BookService.GetBooksForBookCategory(queryModel.MainCategory, queryModel.SubMainCategory, queryModel.BookCategory,
                queryModel.Page, queryModel.ItemsPerPage, queryModel.SortOrder));
        }
    }
}