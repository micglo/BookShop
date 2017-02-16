using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.BookReview;
using BookShop.Service.Interfaces;
using Microsoft.AspNet.Identity;

namespace BookShop.Web.Controllers
{
    public class BookReviewController : BaseController
    {
        public BookReviewController(IBookReviewService bookReviewService, ApplicationUserManager userManager)
        {
            BookReviewService = bookReviewService;
            UserManager = userManager;
        }


        public PartialViewResult BookReviewSummaryPartial(BookReview model)
            => PartialView("_BookReviewSummaryPartial", model);


        public PartialViewResult GetAllByBookId(int bookId)
            => PartialView(BookReviewService.GetAllByBookIdSync(bookId));


        public PartialViewResult AddBookReviewModal(int bookId, string returnUrl)
        {
            var model = new AddBookReviewViewModel
            {
                ReturnUrl = returnUrl
            };

            //pobiera dane z ciasteczka w przypadku gdyby były one tam (żytkownik nie był zalogowany przed dodawaniem recenzji)
            var bookReviewFromCookie = Session["BookReview"] as BookReview;

            model.BookReview = bookReviewFromCookie ?? new BookReview { BookId = bookId };
            return PartialView(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddReviewPost([Bind(Include = "ReviewRate, BookId, Description", Prefix = "BookReview")] BookReview bookReview, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = UserManager.FindByName(userName);
                bookReview.UserId = user.Id;
                var result = await BookReviewService.PostReview(bookReview);
                Session.Remove("BookReview");
                return PartialView("_AddReviewPostPartial", result);
            }

            //Jeśli użytkownik nie jest zalogowany to zwraca błąd z informacją o zalogowaniu i wrzuca dane do ciasteczka
            var loginErrorModel = new ReviewViewModel
            {
                LoginErrorMessage = "Musisz być zalogowany, aby dodać swoją opinię",
                ReturnUrl = returnUrl
            };

            Session["BookReview"] = bookReview;

            return PartialView("_AddReviewPostPartial", loginErrorModel);
        }


        public PartialViewResult EditBookReviewModal()
            => PartialView();


        public async Task<PartialViewResult> EditReview(int bookReviewId)
        {
            var model = await BookReviewService.GetById(bookReviewId);
            return PartialView(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditReviewPost([Bind(Include = "Id,BookId,UserId,ReviewRate,Description")] BookReview bookReview)
        {
            var model = new InfoViewModel();

            //tylko twórca recenzji może ją zmienić
            if (!User.Identity.IsAuthenticated || !User.Identity.GetUserId().Equals(bookReview.UserId))
            {
                model.Errors.Add("Nie jesteś twórca tej recenzji. Nie możesz jej zmienić");
            }
            else
            {
                await BookReviewService.Update(bookReview);
                model.Message = "Twoja recenzja została zmieniona";
            }


            return PartialView("_infoPartial", model);
        }


        public PartialViewResult DeleteBookReviewModal()
            => PartialView();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> DeleteReview(int bookReviewId)
        {
            var model = new InfoViewModel();

            //tylko twórca recenzji może ją usunąć
            var bookReview = await BookReviewService.GetById(bookReviewId);
            if (!User.Identity.IsAuthenticated || !User.Identity.GetUserId().Equals(bookReview.UserId))
            {
                model.Errors.Add("Nie jesteś twórca tej recenzji. Nie możesz jej usunąć");
            }
            else
            {
                await BookReviewService.Delete(bookReviewId);
                model.Message = "Twoja recenzja została usunięta";
            }
            

            return PartialView("_infoPartial", model);
        }


        public PartialViewResult ShowVote(int bookId)
        {
            var model = BookReviewService.CalculateVote(bookId);

            return PartialView("_ShowVotePartial", model);
        }
    }
}