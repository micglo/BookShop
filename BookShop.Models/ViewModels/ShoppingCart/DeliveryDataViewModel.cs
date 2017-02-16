using BookShop.Data;

namespace BookShop.Models.ViewModels.ShoppingCart
{
    public class DeliveryDataViewModel
    {
        public ApplicationUser User { get; set; }
        public bool OtherDeliveryAddress { get; set; }
    }
}