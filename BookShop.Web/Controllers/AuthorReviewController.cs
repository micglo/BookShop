using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.AuthorReview;
using BookShop.Service.Interfaces;
using Microsoft.AspNet.Identity;

namespace BookShop.Web.Controllers
{
    public class AuthorReviewController : BaseController
    {
        public AuthorReviewController(IAuthorReviewService authorReviewService, ApplicationUserManager userManager)
        {
            AuthorReviewService = authorReviewService;
            UserManager = userManager;
        }


        public PartialViewResult AuthorReviewSummaryPartial(AuthorReview model)
            => PartialView("_AuthorReviewSummaryPartial", model);


        public PartialViewResult GetAllByAuthorId(int authorId)
            => PartialView(AuthorReviewService.GetAllByAuthorIdSync(authorId));


        public PartialViewResult AddAuthorReviewModal(int authorId, string returnUrl)
        {
            var model = new AddAuthorReviewViewModel
            {
                ReturnUrl = returnUrl
            };

            //pobiera dane z ciasteczka w przypadku gdyby były one tam (żytkownik nie był zalogowany przed dodawaniem recenzji)
            var authorReviewFromCookie = Session["AuthorReview"] as AuthorReview;

            model.AuthorReview = authorReviewFromCookie ?? new AuthorReview { AuthorId = authorId };
            return PartialView(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddReviewPost([Bind(Include = "ReviewRate, AuthorId, Description", Prefix = "AuthorReview")] AuthorReview authorReview, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = UserManager.FindByName(userName);
                authorReview.UserId = user.Id;
                var result = await AuthorReviewService.PostReview(authorReview);
                Session.Remove("AuthorReview");
                return PartialView("_AddReviewPostPartial", result);
            }

            //Jeśli użytkownik nie jest zalogowany to zwraca błąd z informacją o zalogowaniu i wrzuca dane do ciasteczka
            var loginErrorModel = new ReviewViewModel
            {
                LoginErrorMessage = "Musisz być zalogowany, aby dodać swoją opinię",
                ReturnUrl = returnUrl
            };

            Session["AuthorReview"] = authorReview;

            return PartialView("_AddReviewPostPartial", loginErrorModel);
        }


        public PartialViewResult EditAuthorReviewModal()
            => PartialView();


        public async Task<PartialViewResult> EditReview(int authorReviewId)
        {
            var model = await AuthorReviewService.GetById(authorReviewId);
            return PartialView(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditReviewPost([Bind(Include = "Id,ReviewRate,AuthorId,UserId,Description")]AuthorReview authorReview)
        {
            var model = new InfoViewModel();

            //tylko twórca recenzji może ją zmienić
            if (!User.Identity.IsAuthenticated || !User.Identity.GetUserId().Equals(authorReview.UserId))
            {
                model.Errors.Add("Nie jesteś twórca tej recenzji. Nie możesz jej zmienić");
            }
            else
            {
                await AuthorReviewService.Update(authorReview);
                model.Message = "Twoja recenzja została zmieniona";
            }


            return PartialView("_infoPartial", model);
        }


        public PartialViewResult DeleteAuthorReviewModal()
            => PartialView();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> DeleteReview(int authorReviewId)
        {
            var model = new InfoViewModel();
            var authorReview = await AuthorReviewService.GetById(authorReviewId);

            //tylko twórca recenzji może ją usunąć
            if (!User.Identity.IsAuthenticated || !User.Identity.GetUserId().Equals(authorReview.UserId))
            {
                model.Errors.Add("Nie jesteś twórca tej recenzji. Nie możesz jej usunąć");
            }
            else
            {
                await AuthorReviewService.Delete(authorReviewId);
                model.Message = "Twoja recenzja została usunięta";
            }

            return PartialView("_infoPartial", model);
        }


        public PartialViewResult ShowVote(int authorId)
        {
            var model = AuthorReviewService.CalculateVote(authorId);

            return PartialView("_ShowVotePartial", model);
        }
    }
}