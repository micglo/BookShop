using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.ShoppingCart
{
    public class ShoppingCartBase
    {
        public IEnumerable<ShoppingCartLine> ShoppingCartLines { get; set; }
        public decimal TotalProductsValue { get; set; }
        public decimal TotalCost { get; set; }
        public Delivery Delivery { get; set; }
        public Payment Payment { get; set; }
    }
}