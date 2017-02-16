using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.ShoppingCart;

namespace BookShop.Service.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartViewModel> GetShoppingCart(ShoppingCartSession shoppingCart, string returnUrl = null);
        ShoppingCartViewModel GetShoppingCartModal(ShoppingCartSession shoppingCart);
        Task<ShoppingCartViewModel> GetShoppingCartModalIndex(ShoppingCartSession shoppingCart);
        int GetTotalItem(ShoppingCartSession shoppingCart);


        void AddItem(ShoppingCartSession shoppingCart, int bookId);
        void RemoveItem(ShoppingCartSession shoppingCart, int bookId);
        void RemoveLine(ShoppingCartSession shoppingCart, int bookId);
        void Clear(ShoppingCartSession shoppingCart);
        Task UpdateQuantity(ShoppingCartSession shoppingCart, int bookId, int quantity);


        Task ChangeDelivery(ShoppingCartSession shoppingCart, string deliveryType);
        Task ChangePayment(ShoppingCartSession shoppingCart, string paymentType);


        DeliveryDataViewModel GetDeliveryData(ShoppingCartSession shoppingCart, ApplicationUser user);
        OtherDeliveryAddressViewModel GetDeliveryAddressViewModel(ShoppingCartSession shoppingCart);
        void SetDeliveryAddress(ShoppingCartSession shoppingCart, OtherDeliveryAddressViewModel model);
        bool IsOtherDeliveryAddress(ShoppingCartSession shoppingCart);


        Task<SummaryViewModel> GetSummaryViewModel(ShoppingCartSession shoppingCart, ApplicationUser user);
        Task<InfoViewModel> Checkout(ShoppingCartSession shoppingCart, ApplicationUser user);
    }
}