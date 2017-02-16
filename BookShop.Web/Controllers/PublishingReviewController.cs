using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.PublishingReview;
using BookShop.Service.Interfaces;
using Microsoft.AspNet.Identity;

namespace BookShop.Web.Controllers
{
    public class PublishingReviewController : BaseController
    {
        public PublishingReviewController(IPublishingReviewService publishingReviewService, ApplicationUserManager userManager)
        {
            PublishingReviewService = publishingReviewService;
            UserManager = userManager;
        }


        public PartialViewResult PublishingReviewSummaryPartial(PublishingReview model)
            => PartialView("_PublishingReviewSummaryPartial", model);


        public PartialViewResult GetAllByPublishingId(int publishingId)
            => PartialView(PublishingReviewService.GetAllByPublishingIdSync(publishingId));


        public PartialViewResult AddPublishingReviewModal(int publishingId, string returnUrl)
        {
            var model = new AddPublishingReviewViewModel
            {
                ReturnUrl = returnUrl
            };

            //pobiera dane z ciasteczka w przypadku gdyby były one tam (żytkownik nie był zalogowany przed dodawaniem recenzji)
            var publishingReviewFromCookie = Session["PublishingReview"] as PublishingReview;

            model.PublishingReview = publishingReviewFromCookie ?? new PublishingReview { PublishingId = publishingId };
            return PartialView(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddReviewPost([Bind(Include = "ReviewRate, PublishingId, Description", Prefix = "PublishingReview")]
        PublishingReview publishingReview, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = UserManager.FindByName(userName);
                publishingReview.UserId = user.Id;
                var result = await PublishingReviewService.PostReview(publishingReview);
                Session.Remove("PublishingReview");
                return PartialView("_AddReviewPostPartial", result);
            }

            //Jeśli użytkownik nie jest zalogowany to zwraca błąd z informacją o zalogowaniu i wrzuca dane do ciasteczka
            var loginErrorModel = new ReviewViewModel
            {
                LoginErrorMessage = "Musisz być zalogowany, aby dodać swoją opinię",
                ReturnUrl = returnUrl
            };

            Session["PublishingReview"] = publishingReview;

            return PartialView("_AddReviewPostPartial", loginErrorModel);
        }


        public PartialViewResult EditPublishingReviewModal()
            => PartialView();


        public async Task<PartialViewResult> EditReview(int publishingReviewId)
        {
            var model = await PublishingReviewService.GetById(publishingReviewId);
            return PartialView(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditReviewPost([Bind(Include = "Id,PublishingId,UserId,ReviewRate,Description")]PublishingReview publishingReview)
        {
            var model = new InfoViewModel();

            //tylko twórca recenzji może ją zmienić
            if (!User.Identity.IsAuthenticated || !User.Identity.GetUserId().Equals(publishingReview.UserId))
            {
                model.Errors.Add("Nie jesteś twórca tej recenzji. Nie możesz jej zmienić");
            }
            else
            {
                await PublishingReviewService.Update(publishingReview);
                model.Message = "Twoja recenzja została zmieniona";
            }


            return PartialView("_infoPartial", model);
        }


        public PartialViewResult DeletePublishingReviewModal()
            => PartialView();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> DeleteReview(int publishingReviewId)
        {
            var model = new InfoViewModel();

            //tylko twórca recenzji może ją usunąć
            var publishingReview = await PublishingReviewService.GetById(publishingReviewId);
            if (!User.Identity.IsAuthenticated || !User.Identity.GetUserId().Equals(publishingReview.UserId))
            {
                model.Errors.Add("Nie jesteś twórca tej recenzji. Nie możesz jej usunąć");
            }
            else
            {
                await PublishingReviewService.Delete(publishingReviewId);
                model.Message = "Twoja recenzja została usunięta";
            }


            return PartialView("_infoPartial", model);
        }


        public PartialViewResult ShowVote(int publishingId)
        {
            var model = PublishingReviewService.CalculateVote(publishingId);

            return PartialView("_ShowVotePartial", model);
        }
    }
}