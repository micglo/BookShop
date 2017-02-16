using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using BookShop.Models.ViewModels.Account;
using BookShop.Service.Interfaces;
using BookShop.Web.Common.filters;
using Microsoft.AspNet.Identity.Owin;

namespace BookShop.Web.Controllers
{
    [MyAuthorize]
    [RoutePrefix("MojeKonto")]
    public class ManageController : BaseController
    {
        public ManageController(ApplicationUserManager userManager, SignInManager<ApplicationUser, string> signInManager, IAuthorReviewService authorReviewService, IBookReviewService bookReviewService, IPublishingReviewService publishingReviewService, ITransactionService transactionService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            AuthorReviewService = authorReviewService;
            BookReviewService = bookReviewService;
            PublishingReviewService = publishingReviewService;
            TransactionService = transactionService;
        }


        [Route("")]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            var vm = new ManageLoginsViewModel();

            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));

            if (!result.Succeeded)
            {
                vm.Errors = InvalidResult("Nie udało się usunąć dostawcy logowania").Errors;
                return PartialView("_manageLoginsPartial", vm);
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                vm.Errors = InvalidResult("Nie odnaleziono użytkownika").Errors;
                return PartialView("_manageLoginsPartial", vm);
            }

            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            vm.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;

            vm.CurrentLogins = userLogins;
            vm.OtherLogins = otherLogins;

            vm.Message = "Usługa logowania została usunięta";

            return PartialView("_manageLoginsPartial", vm);
        }


        [Route("~/ZmienHaslo", Name = "ChangePassword")]
        public ActionResult ChangePassword()
        {
            return View();
        }


        [Route("~/ZmienHaslo", Name = "ChangePasswordPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_infoPartial", InvalidModel());

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
                return PartialView("_infoPartial", InvalidResult("Resetowanie hasła nie powiodło się"));

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
                return PartialView("_infoPartial", InvalidResult("Nie odnaleziono użytkownika"));

            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            var vm = new InfoViewModel
            {
                Message = "Hasło zostało zmienione"
            }; 

            return PartialView("_infoPartial", vm);
        }


        [Route("~/UstawHaslo", Name = "SetPassword")]
        public ActionResult SetPassword()
        {
            return View();
        }


        [Route("~/UstawHaslo", Name = "SetPasswordPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_infoPartial", InvalidModel());

            var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

            if (!result.Succeeded)
                return PartialView("_infoPartial", InvalidResult("Ustawienie hasła nie powiodło się"));

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
                return PartialView("_infoPartial", InvalidResult("Nie odnaleziono użytkownika"));

            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            var vm = new InfoViewModel
            {
                Message = "Hasło zostało ustawione"
            };

            return PartialView("_infoPartial", vm);
        }


        [Route("~/UslugiLogowania", Name = "ManageLogins")]
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            var vm = new ManageLoginsViewModel();
            switch (message)
            {
                case ManageMessageId.Error:
                    vm.Errors = InvalidResult("Wystąpił błąd").Errors;
                    break;
                case ManageMessageId.AddLoginSuccess:
                    vm.Message = "Dodano nową usługe logowania";
                    break;
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                vm.Errors = InvalidResult("Nie odnaleziono użytkownika").Errors;
                return View(vm);
            }

            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            vm.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            vm.CurrentLogins = userLogins;
            vm.OtherLogins = otherLogins;

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }


        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins", new { Message = ManageMessageId.AddLoginSuccess }) : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }


        [Route("~/MojeRecenzje", Name = "MyReviews")]
        public async Task<ActionResult> MyReviews()
        {
            var userId = User.Identity.GetUserId();
            var myAuthorReviews = await AuthorReviewService.GetMyReviews(userId);
            var myBookReviews = await BookReviewService.GetMyReviews(userId);
            var myPublishingReviews = await PublishingReviewService.GetMyReviews(userId);

            var vm = new MyReviewsViewModel
            {
                MyAuthorReviews = myAuthorReviews,
                MyBookReviews = myBookReviews,
                MyPublishingReviews = myPublishingReviews
            };

            return View(vm);
        }


        public async Task<ActionResult> GetMyBookReviewsPartial()
        {
            var userId = User.Identity.GetUserId();
            var myBookReviews = await BookReviewService.GetMyReviews(userId);

            return PartialView(myBookReviews);
        }


        public async Task<ActionResult> GetMyAuthorReviewsPartial()
        {
            var userId = User.Identity.GetUserId();
            var myAuthorReviews = await AuthorReviewService.GetMyReviews(userId);

            return PartialView(myAuthorReviews);
        }


        public async Task<ActionResult> GetMyPublishingReviewsPartial()
        {
            var userId = User.Identity.GetUserId();
            var myPublishingReviews = await PublishingReviewService.GetMyReviews(userId);

            return PartialView(myPublishingReviews);
        }


        [Route("~/MojProfil", Name = "MyProfile")]
        public async Task<ActionResult> MyProfile()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            return View(user);
        }


        [Route("~/EdytujMojeDane", Name = "UpdateMyProfileData")]
        public async Task<ActionResult> UpdateMyProfileData()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var model = new UserDataPostViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Street = user.Street,
                PostCode = user.PostCode,
                IsCompany = user.IsCompany,
                Email = user.Email
            };

            return View(model);
        }


        public async Task<ActionResult> UpdateMyProfileCompanyData()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var model = new UserCompanyDataPostViewModel
            {
                CompanyName = user.CompanyName,
                Regon = user.Regon,
                Nip = user.Nip
            };

            return PartialView(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateMyProfileDataPost([Bind(Include = "FirstName, LastName, PhoneNumber, Street, City, PostCode, IsCompany, CompanyName, Regon, Nip, Email")]
        Data.ApplicationUser model)
        {
            if (!ModelState.IsValid)
                return PartialView("_infoPartial", InvalidModel());

            var user = await UserManager.FindByEmailAsync(model.Email);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.City = model.City;
            user.Street = model.Street;
            user.PostCode = model.PostCode;
            user.PhoneNumber = model.PhoneNumber;
            user.IsCompany = model.IsCompany;
            user.CompanyName = model.CompanyName;
            user.Regon = model.Regon;
            user.Nip = model.Nip;

            if (!model.IsCompany)
            {
                user.CompanyName = string.Empty;
                user.Regon = string.Empty;
                user.Nip = string.Empty;
            }

            var result = await UserManager.UpdateAsync(user);

            if (!result.Succeeded)
                return PartialView("_infoPartial", InvalidResult("Edycja profilu nie powiodła się."));
           
            var vm = new InfoViewModel
            {
                Message = "Twoje dane zostały zaktualizowane"
            };

            return PartialView("_infoPartial", vm);
        }


        [Route("~/MojeTransakcje", Name = "MyTransactions")]
        public async Task<ActionResult> MyTransactions()
        {
            var userId = User.Identity.GetUserId();
            var myTrsansactions = await TransactionService.GetAllByUserId(userId);

            return View(myTrsansactions);
        }


        [Route("~/MojeTransakcje/{id}", Name = "TransactionDetails")]
        public async Task<ActionResult> TransactionDetails(int id)
        {
            if (! await TransactionService.TransactionExists(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var userId = User.Identity.GetUserId();

            var transaction = await TransactionService.GetById(id);

            if (!transaction.UserId.Equals(userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var vm = await TransactionService.GetTransationDetail(id);
            return View(vm);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";


        private IAuthenticationManager AuthenticationManager 
            => HttpContext.GetOwinContext().Authentication;


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user?.PasswordHash != null;
        }


        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user?.PhoneNumber != null;
        }


        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error,
            AddLoginSuccess
        }

        #endregion
    }
}