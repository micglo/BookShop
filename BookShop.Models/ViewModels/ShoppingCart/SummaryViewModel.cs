using BookShop.Data;

namespace BookShop.Models.ViewModels.ShoppingCart
{
    /// <summary>
    /// Model podsumowania zakupów
    /// </summary>
    public class SummaryViewModel : ShoppingCartBase
    {
        public OtherDeliveryAddressViewModel OtherDeliveryAddress { get; set; }
        public ApplicationUser User { get; set; }
    }
}