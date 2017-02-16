using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.ShoppingCart
{
    public class ShoppingCartSession
    {
        public List<ShoppingCartLineSession> ShoppingCartLines { get; set; }
        public Delivery Delivery { get; set; }
        public Payment Payment { get; set; }
        public string ReturnUrl { get; set; }
        public OtherDeliveryAddressViewModel OtherDeliveryAddressViewModel { get; set; } = new OtherDeliveryAddressViewModel();
    }
}