using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.ShoppingCart
{
    /// <summary>
    /// Model służący do wyświetlenia zawartości koszyka w metodzie Index i modalu
    /// </summary>
    public class ShoppingCartViewModel : ShoppingCartBase
    {
        public List<Delivery> DeliveryOptions { get; set; }
        public List<Payment> PaymentOptions { get; set; }
        public string ReturnUrl { get; set; }
    }
}