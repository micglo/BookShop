using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BookShop.Models.ViewModels.Account;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Web.Common.filters;

namespace BookShop.Web.Controllers
{
    [RoutePrefix("Konto")]
    public class AccountController : BaseController
    {
        public AccountController(ApplicationUserManager userManager, SignInManager<ApplicationUser, string> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [Route("~/Zaloguj", Name = "Login")]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }


        [Route("~/Zaloguj", Name = "LoginPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "Email, Password, RememberMe, ReturnUrl")] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Errors = InvalidModel().Errors;
                return View(model);
            }

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                model.Errors = InvalidUser().Errors;
                return View(model);
            }

            if (!await UserManager.IsEmailConfirmedAsync(user.Id))
            {
                model.Errors = EmailNotConfirmed().Errors;
                return View(model);
            }

            return await PasswordSignIn(model, model.ReturnUrl);
        }


        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            var vm = new VerifyCodeViewModel();
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
                vm.Errors = InvalidResult("Weryfukacja kodu nie powiadła się").Errors;

            vm.Provider = provider;
            vm.ReturnUrl = returnUrl;
            vm.RememberMe = rememberMe;
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode([Bind(Include = "Provider, Code, ReturnUrl, RememberBrowser, RememberMe")] VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Errors = InvalidModel().Errors;
                return View(model);
            }
            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result =
                await
                    SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe,
                        rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", @"Niepoprawny kod");
                    return View(model);
            }
        }


        [Route("~/NoweKonto", Name = "Register")]
        public ActionResult Register()
        {
            return View();
        }


        [Route("~/NoweKonto", Name = "RegisterPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_infoPartial", InvalidModel());

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                IsCompany = false
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return FailedToCreateNewAccount(result);

            await SendEmailConfirmationTokenAsync(user.Id, "Aktywuj swoje konto");

            var vm = new InfoViewModel
            {
                Message = "Konto zostało utworzone. Sprawdź swoją skrzynkę email i aktywuj konto."
            };

            return PartialView("_infoPartial", vm);
        }


        [Route("~/PotwierdzEmail", Name = "ConfirmEmail")]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
                return View(InvalidResult("Kod aktywacyjny lub ID użytkownika nie zostało przesłane"));

            if (await UserManager.IsEmailConfirmedAsync(userId))
                return View(InvalidResult("Konto jest już aktywne"));

            var result = await UserManager.ConfirmEmailAsync(userId, code);

            if (!result.Succeeded)
                return View(InvalidResult("Aktywacja konta nie powiodła się, skontaktuj się z administratorem"));

            var vm = new InfoViewModel
            {
                Message = "Konto zostało aktywowane"
            };

            return View(vm);
        }


        [Route("~/ZapomnianeHaslo", Name = "ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [Route("~/ZapomnianeHaslo", Name = "ForgotPasswordPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_infoPartial", InvalidModel());

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user == null)
                return PartialView("_infoPartial", InvalidUser());

            if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                return PartialView("_infoPartial", EmailNotConfirmed());

            ResetPasswordLink(user.Id);

            var vm = new InfoViewModel
            {
                Message = "Link do zresetowania hasła został przesłany na podany adres email."
            };

            return PartialView("_infoPartial", vm);
        }


        [Route("~/ResetujHaslo", Name = "ResetPassword")]
        public ActionResult ResetPassword(string code)
        {
            var model = new ResetPasswordViewModel();
            if (string.IsNullOrEmpty(code))
            {
                model.Error = "Kod jest wymagany";
            }
            return View(model);
        }


        [Route("~/ResetujHaslo", Name = "ResetPasswordPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword([Bind(Include = "Email, Password, ConfirmPassword, Code")] ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_infoPartial", InvalidModel());

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user == null)
                return PartialView("_infoPartial", InvalidUser());

            if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                return PartialView("_infoPartial", EmailNotConfirmed());

            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);

            if (!result.Succeeded)
                return PartialView("_infoPartial", InvalidResult("Resetowanie hasła nie powiodło się"));

            var vm = new InfoViewModel
            {
                Message = "Hasło zostało zmienione"
            };

            return PartialView("_infoPartial", vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider,
                Url.Action("ExternalLoginCallback", "Account", new {ReturnUrl = returnUrl}));
        }


        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var externalLoginResult = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (externalLoginResult)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new {ReturnUrl = returnUrl, RememberMe = false});
                case SignInStatus.Failure:
                default:
                    if (!string.IsNullOrEmpty(loginInfo.Email))
                    {
                        var user = await UserManager.FindByEmailAsync(loginInfo.Email);

                        if (user != null)
                        {
                            var result = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                            if (!result.Succeeded) return null;
                            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                            if (await UserManager.IsEmailConfirmedAsync(user.Id)) return RedirectToLocal(returnUrl);
                            user.EmailConfirmed = true;
                            await UserManager.UpdateAsync(user);
                            return RedirectToLocal(returnUrl);
                        }
                    }

                    // If the user does not have an account, then prompt the user to create an account
                    var model = new ExternalLoginConfirmationViewModel
                    {
                        ReturnUrl = returnUrl,
                        LoginProvider = loginInfo.Login.LoginProvider,
                        Email = loginInfo.Email
                    };

                    return View("ExternalLoginConfirmation", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation([Bind(Include = "Email, ReturnUrl, LoginProvider")] ExternalLoginConfirmationViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Manage");

            if (!ModelState.IsValid)
            {
                model.Errors = InvalidModel().Errors;
                return View(model);
            }

            var info = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                model.Errors = InvalidResult("Wystąpił błąd logowania").Errors;
                return View(model);
            }
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var createResult = await UserManager.CreateAsync(user);
            if (!createResult.Succeeded)
            {
                var errorList = new List<string>();
                var userTakenError = 0;
                foreach (var error in createResult.Errors)
                {
                    if (error.EndsWith("is already taken."))
                    {
                        userTakenError++;
                        if (userTakenError > 1)
                            continue;
                        errorList.Add("Użytkownik o podanym adresie email już istnieje.");
                    }
                    else errorList.Add(error);
                }
                model.Errors = errorList;
                return View(model);
            }

            var addLoginResult = await UserManager.AddLoginAsync(user.Id, info.Login);
            if (!addLoginResult.Succeeded)
            {
                model.Errors = InvalidResult("Wystąpił błąd powiązania konta").Errors;
                return View(model);
            }

            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            return RedirectToLocal(model.ReturnUrl);
        }


        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var model = new SendCodeViewModel();
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                model.Errors = InvalidResult("Wystąpił błąd logowania").Errors;
                return View(model);
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions =
                userFactors.Select(purpose => new SelectListItem {Text = purpose, Value = purpose}).ToList();

            model.Providers = factorOptions;
            model.ReturnUrl = returnUrl;
            model.RememberMe = rememberMe;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode([Bind(Include = "SelectedProvider, ReturnUrl, RememberMe")] SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Errors = InvalidModel().Errors;
                return View(model);
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                model.Errors = InvalidResult("Nie udalo się wygenerować kodu").Errors;
                return View(model);
            }
            return RedirectToAction("VerifyCode",
                new {Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe});
        }


        [Route("~/Wyloguj", Name = "LogOff")]
        [HttpPost]
        [MyAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }


        [Route("~/PrzeslijLinkDoPotwierdzeniaEmail", Name = "ResendEmailConfirmation")]
        public ActionResult ResendEmailConfirmation()
        {
            return View();
        }


        [Route("~/PrzeslijLinkDoPotwierdzeniaEmail", Name = "ResendEmailConfirmationPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResendEmailConfirmation(ResendEmailConfirmationViewModel model)
        {
            var userToSendLink = UserManager.FindByEmail(model.Email);
            var accessToLink = UserManager.CheckPasswordAsync(userToSendLink, model.Password);

            if (!ModelState.IsValid)
                return PartialView("_infoPartial", InvalidModel());

            var user = await UserManager.FindByNameAsync(model.Email);

            if (user == null)
                return PartialView("_infoPartial", InvalidUser());

            if (!await accessToLink)
                return PartialView("_infoPartial", InvalidResult("Niepoprawny adres email lub hasło"));

            if (await UserManager.IsEmailConfirmedAsync(user.Id))
                return PartialView("_infoPartial", InvalidResult("Konto jest już aktywne"));

            await SendEmailConfirmationTokenAsync(user.Id, "Aktywuj swoje konto");

            var vm = new InfoViewModel
            {
                Message = "Link aktywacyjny został przesłany na podany adres email"
            };

            return PartialView("_infoPartial", vm);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";


        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }


            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }


            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties {RedirectUri = RedirectUri};
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }


        private async Task<string> SendEmailConfirmationTokenAsync(string userId, string subject)
        {
            var code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = Url.Action("ConfirmEmail", "Account",
                new {userId, code}, Request.Url?.Scheme);

            await UserManager.SendEmailAsync(userId, subject,
                "<a href=\"" + callbackUrl + "\">Kliknij tutaj</a>, aby aktywować swoje konto.");

            return callbackUrl;
        }


        private async Task<ActionResult> PasswordSignIn(LoginViewModel model, string returnUrl)
        {
            var result =
                await
                    SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                        shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode",
                        new {ReturnUrl = returnUrl, RememberMe = model.RememberMe});
                default:
                    model.Errors = InvalidResult("Niepoprawny adres email lub hasło").Errors;
                    return View(model);
            }
        }


        private async void ResetPasswordLink(string userId)
        {
            var code = await UserManager.GeneratePasswordResetTokenAsync(userId);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = userId, code = code },
                protocol: Request.Url?.Scheme);
            await
                UserManager.SendEmailAsync(userId, "Resetowanie hasła",
                    "<a href=\"" + callbackUrl + "\">Kliknij tutaj</a>, aby zresetować swoje hasło.");
        }


        private ActionResult FailedToCreateNewAccount(IdentityResult result)
        {
            var vm = new InfoViewModel();
            var errorList = new List<string>();
            var userTakenError = 0;
            foreach (var error in result.Errors)
            {
                if (error.EndsWith("is already taken."))
                {
                    userTakenError++;
                    if (userTakenError > 1)
                        continue;
                    errorList.Add("Użytkownik o podanym adresie email już istnieje.");
                }
                else errorList.Add(error);
            }
            vm.Errors = errorList;
            return PartialView("_infoPartial", vm);
        }

        #endregion
    }
}