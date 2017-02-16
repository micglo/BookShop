using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Models.ViewModels.ShoppingCart;
using BookShop.Service.Interfaces;
using BookShop.Web.Common.filters;
using Microsoft.AspNet.Identity;

namespace BookShop.Web.Controllers
{
    [RoutePrefix("Koszyk")]
    public class CartController : BaseController
    {
        public CartController(IShoppingCartService shoppingCartService, ApplicationUserManager userManager)
        {
            ShoppingCartService = shoppingCartService;
            UserManager = userManager;
        }


        [Route("~/MojeZakupy", Name = "Index")]
        public async Task<ActionResult> Index(ShoppingCartSession shoppingCart, string returnUrl)
            => View(await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));


        public async Task<PartialViewResult> IndexPartial(ShoppingCartSession shoppingCart, string returnUrl)
            => PartialView(await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));


        public PartialViewResult CartModal(ShoppingCartSession shoppingCart)
            => PartialView(ShoppingCartService.GetShoppingCartModal(shoppingCart));


        public async Task<PartialViewResult> ModalIndex(ShoppingCartSession shoppingCart)
            => PartialView(await ShoppingCartService.GetShoppingCartModalIndex(shoppingCart));


        public ActionResult GetTotalItem(ShoppingCartSession shoppingCart)
            => ShoppingCartService.GetTotalItem(shoppingCart) > 0 ? Json(ShoppingCartService.GetTotalItem(shoppingCart), JsonRequestBehavior.AllowGet) : null;


        public async Task<PartialViewResult> AddToCart(ShoppingCartSession shoppingCart, int bookId)
        {
            ShoppingCartService.AddItem(shoppingCart, bookId);

            return PartialView("ModalIndex", await ShoppingCartService.GetShoppingCartModalIndex(shoppingCart));
        }

        public async Task<PartialViewResult> RemoveFromCart(ShoppingCartSession shoppingCart, int bookId, string returnUrl)
        {
            ShoppingCartService.RemoveItem(shoppingCart, bookId);

            return PartialView("IndexPartial", await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));
        }


        public async Task<PartialViewResult> RemoveFromCartModal(ShoppingCartSession shoppingCart, int bookId)
        {
            ShoppingCartService.RemoveItem(shoppingCart, bookId);

            return PartialView("ModalIndex", await ShoppingCartService.GetShoppingCartModalIndex(shoppingCart));
        }


        public async Task<PartialViewResult> RemoveAllFromCart(ShoppingCartSession shoppingCart, int bookId, string returnUrl)
        {
            ShoppingCartService.RemoveLine(shoppingCart, bookId);

            return PartialView("IndexPartial", await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));
        }


        public async Task<PartialViewResult> RemoveAllFromCartModal(ShoppingCartSession shoppingCart, int bookId)
        {
            ShoppingCartService.RemoveLine(shoppingCart, bookId);

            return PartialView("ModalIndex", await ShoppingCartService.GetShoppingCartModalIndex(shoppingCart));
        }


        public async Task<PartialViewResult> ClearCart(ShoppingCartSession shoppingCart, string returnUrl)
        {
            ShoppingCartService.Clear(shoppingCart);

            return PartialView("IndexPartial", await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));
        }


        public async Task<PartialViewResult> ClearCartModal(ShoppingCartSession shoppingCart)
        {
            ShoppingCartService.Clear(shoppingCart);

            return PartialView("ModalIndex", await ShoppingCartService.GetShoppingCartModalIndex(shoppingCart));
        }


        public async Task<PartialViewResult> UpdateCartQuantity(ShoppingCartSession shoppingCart, int bookId, string returnUrl, int quantity)
        {
            await ShoppingCartService.UpdateQuantity(shoppingCart, bookId, quantity);

            return PartialView("IndexPartial", await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));
        }


        public async Task<PartialViewResult> UpdateCartModalQuantity(ShoppingCartSession shoppingCart, int bookId, int quantity)
        {
            await ShoppingCartService.UpdateQuantity(shoppingCart, bookId, quantity);

            return PartialView("ModalIndex", await ShoppingCartService.GetShoppingCartModalIndex(shoppingCart));
        }


        public async Task<PartialViewResult> SetDeliveryMethod(ShoppingCartSession shoppingCart, string delivery, string returnUrl)
        {
            await ShoppingCartService.ChangeDelivery(shoppingCart, delivery);

            return PartialView("IndexPartial", await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));
        }


        public async Task<PartialViewResult> SetPaymentMethod(ShoppingCartSession shoppingCart, string payment, string returnUrl)
        {
            await ShoppingCartService.ChangePayment(shoppingCart, payment);
            return PartialView("IndexPartial", await ShoppingCartService.GetShoppingCart(shoppingCart, returnUrl));
        }


        [Route("~/DaneAdresowe", Name = "DeliveryData")]
        [MyAuthorize]
        public async Task<ActionResult> DeliveryData(ShoppingCartSession shoppingCart)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var model = ShoppingCartService.GetDeliveryData(shoppingCart, user);
            return View(model);
        }


        [MyAuthorize]
        public ActionResult OtherDeliveryAddressPartial(ShoppingCartSession shoppingCart)
            => PartialView(ShoppingCartService.GetDeliveryAddressViewModel(shoppingCart));


        [HttpPost]
        [MyAuthorize]
        public ActionResult UpdateDeliveryData(ShoppingCartSession shoppingCart, OtherDeliveryAddressViewModel model)
        {
            ShoppingCartService.SetDeliveryAddress(shoppingCart, model);
            return RedirectToAction("Summary");
        }


        [Route("~/Podsumowanie", Name = "Summary")]
        [MyAuthorize]
        public async Task<ActionResult> Summary(ShoppingCartSession shoppingCart)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            if (string.IsNullOrEmpty(user.FirstName) && !ShoppingCartService.IsOtherDeliveryAddress(shoppingCart))
                return RedirectToAction("UpdateMyProfileData", "Manage");

            return View(await ShoppingCartService.GetSummaryViewModel(shoppingCart, user));
        }


        [MyAuthorize]
        public async Task<ActionResult> SummaryPartial(ShoppingCartSession shoppingCart)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            return PartialView(await ShoppingCartService.GetSummaryViewModel(shoppingCart, user));
        }

        [Route("~/RealizujTransakcje", Name = "Checkout")]
        [MyAuthorize]
        public async Task<ActionResult> Checkout(ShoppingCartSession shoppingCart)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var result = await ShoppingCartService.Checkout(shoppingCart, user);

            return View(result);
        }
    }
}