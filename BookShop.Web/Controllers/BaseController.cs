using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Service.Interfaces;
using Microsoft.AspNet.Identity.Owin;

namespace BookShop.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected SignInManager<ApplicationUser, string> SignInManager;
        protected ApplicationUserManager UserManager;

        protected IAuthorService AuthorService;
        protected IAuthorReviewService AuthorReviewService;
        protected IBookService BookService;
        protected IBookReviewService BookReviewService;
        protected IMenuService MenuService;
        protected IPublishingService PublishingService;
        protected IPublishingReviewService PublishingReviewService;
        protected IShoppingCartService ShoppingCartService;
        protected ITransactionService TransactionService;

        protected InfoViewModel InvalidModel()
        {
            var vm = new InfoViewModel();
            var errorList = new List<string>();
            foreach (var modelState in ModelState.Values)
            {
                errorList.AddRange(modelState.Errors.Select(error => error.ErrorMessage));
            }
            vm.Errors = errorList;

            return vm;
        }


        protected InfoViewModel InvalidResult(string msg)
        {
            var vm = new InfoViewModel();
            var errorList = new List<string> { msg };
            vm.Errors = errorList;
            return vm;
        }


        protected InfoViewModel InvalidUser()
            => InvalidResult("Użytkownik o podanym adresie email nie istnieje");


        protected InfoViewModel EmailNotConfirmed()
            => InvalidResult("Konto nie zostało aktywowane");
    }
}